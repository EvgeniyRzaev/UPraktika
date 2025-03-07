using System;
using System.IO;
using System.Linq;
using System.Reactive;
using EventApp.Models;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System.Threading.Tasks;

namespace EventApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private static readonly Random random = new Random();
        private Bitmap captchaImage;
        private string captchaText;
        private string captcha;
        private int idUser;
        private string password1;
        private readonly MainWindowViewModel _mainWindowViewModel;

        private int failedAttempts;
        private bool isBlocked;
        private DateTime blockEndTime;
        private string errorMessage;

        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            RefreshCaptchaCommand = ReactiveCommand.Create(GenerateCaptcha);
            LoginCommand = ReactiveCommand.CreateFromTask(UserData);
            GenerateCaptcha();
        }

        public int IdUser
        {
            get => idUser;
            set => this.RaiseAndSetIfChanged(ref idUser, value);
        }

        public string Password1
        {
            get => password1;
            set => this.RaiseAndSetIfChanged(ref password1, value);
        }

        public string Captcha
        {
            get => captcha;
            set => this.RaiseAndSetIfChanged(ref captcha, value);
        }

        public Bitmap CaptchaImage
        {
            get => captchaImage;
            set => this.RaiseAndSetIfChanged(ref captchaImage, value);
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set => this.RaiseAndSetIfChanged(ref errorMessage, value);
        }

        public ReactiveCommand<Unit, Unit> RefreshCaptchaCommand { get; }
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        private void GenerateCaptcha()
        {
            captchaText = GenerateRandomText(4);
            CaptchaImage = CreateCaptchaImage(captchaText);
        }

        private static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Bitmap CreateCaptchaImage(string text)
        {
            using (var memoryStream = new MemoryStream())
            {
                CaptchaGenerator.GenerateImage(text, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return new Bitmap(memoryStream);
            }
        }

        public async Task UserData()
        {
            if (isBlocked && DateTime.Now < blockEndTime)
            {
                var remainingTime = blockEndTime - DateTime.Now;
                ErrorMessage = $"Вход заблокирован. Попробуйте снова через {remainingTime.Seconds} секунд.";
                return;
            }

            var user = db.Users.FirstOrDefault(x => x.UserId == IdUser && x.Password == Password1);
            if (user != null && Captcha.Equals(captchaText, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Успешно");
                _mainWindowViewModel.CurrentView = new OrganizatorViewModel(_mainWindowViewModel, user);
                failedAttempts = 0; // сбрасываем счетчик неудачных попыток
                ErrorMessage = string.Empty; // очищаем сообщение об ошибке
            }
            else
            {
                Console.WriteLine("Ошибка входа: неверные данные или капча.");
                failedAttempts++;

                if (failedAttempts >= 3)
                {
                    isBlocked = true;
                    blockEndTime = DateTime.Now.AddSeconds(10);
                    ErrorMessage = "Вход заблокирован на 10 секунд.";
                }
                else
                {
                    ErrorMessage = "Ошибка входа: неверные данные или капча.";
                }

                GenerateCaptcha(); // Обновляем капчу при ошибке
            }
        }
    }
}