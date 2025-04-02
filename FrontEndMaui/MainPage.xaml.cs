using FrontEndMaui.Entidades;
using Newtonsoft.Json;

namespace FrontEndMaui
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            ReqLogin req = new ReqLogin();

            req.correo = txtCorreo.Text;
            req.password = txtPassword.Text;

            HttpResponseMessage respuestaHttp = new HttpResponseMessage();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient()) {
                respuestaHttp = await httpClient.PostAsync("url", jsonContent);
            }

            if (respuestaHttp.IsSuccessStatusCode) {
                var responseContent = await respuestaHttp.Content.ReadAsStringAsync();

                ResLogin res = new ResLogin();
                res.usuario = new Usuario();
                res = JsonConvert.DeserializeObject<ResLogin>(responseContent);

                if (res.resultado)
                {
                    Sesion.usuario = new Usuario();
                    Sesion.usuario.nombre = res.usuario.nombre;
                    Sesion.usuario.apellidos = res.usuario.apellidos;
                    Sesion.usuario.correoElectronico = res.usuario.correoElectronico;
                    Sesion.usuario.Id = res.usuario.Id;

                    //Navigation.PushAsync(new Dashboard());
                else
                    {
                        await DisplayAlert("Login incorrecto", "Usuario o contraseña incorrecto", "Aceptar");
                    }

                }
                else
                {
                    await DisplayAlert("Error de conexion", "No hay respuesta del servidor", "Aceptar");
                }
            }
        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            //ir a registrarse
        }
    }

}
