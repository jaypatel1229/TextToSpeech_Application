using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Linq;
using Xamarin.Essentials;
using TextToSpeech = Xamarin.Essentials.TextToSpeech;

namespace Text_To_Speech_AppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnSpeak;
        private EditText edtSpeak;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnSpeak = FindViewById<Button>(Resource.Id.btnSpeak);
            edtSpeak = FindViewById<EditText>(Resource.Id.edtSpeak);

            btnSpeak.Click += BtnSpeak_Click;
        }

        private async void BtnSpeak_Click(object sender, EventArgs e)
        {
            string speek = edtSpeak.Text;
            var locales = await TextToSpeech.GetLocalesAsync();



            // Grab the first locale
            var English = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = .98f,
                Pitch = 1.0f,
                Locale = English
            };

            await TextToSpeech.SpeakAsync(speek, settings);
        }
    }
}