using Microsoft.Extensions.Configuration;
using ProductoAppMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ProductoAppMAUI.Service
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APIService()
        {
            _baseUrl = "https://apiproductos20240110075942.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        public async Task<bool> DeleteProducto(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync($"/api/Producto/{IdProducto}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            //var response = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{Id}");
            var response = await _httpClient.GetAsync($"/api/Producto/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return null;
        }

        public async Task<User> GetUser(String Correo, String Contrasenia)
        {
            var response = await _httpClient.GetAsync($"/api/Usuario/{Correo}/{Contrasenia}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                User user2 = JsonConvert.DeserializeObject<User>(json_response);
                return user2;
            }
            return null;
        }

        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return null;

        }

        public async Task<List<Resena>> GetResenas(string IdProducto)
        {
            var response = await _httpClient.GetAsync($"/Resena/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Resena> resenas= JsonConvert.DeserializeObject<List<Resena>>(json_response);
                return resenas;
            }
            return null;

        }

        public async Task<List<Carrito>> GetProductosCarrito(string IdUsuario)
        {
            var response = await _httpClient.GetAsync($"/api/ProductoEnCarrito/ObtenerProductosEnCarrito/IdUsuario/{IdUsuario}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Carrito> carrito = JsonConvert.DeserializeObject<List<Carrito>>(json_response);
                return carrito;
            }
            return null;

        }

        public async Task<bool> DeleteCarrito(string IdUsuario)
        {
            var response = await _httpClient.DeleteAsync($"api/ProductoEnCarrito/EliminarProductosEnCarritoPorUsuario/{IdUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> DeleteProductoCarrito(string IdProductoEnCarrito)
        {
            var response = await _httpClient.DeleteAsync($"api/ProductoEnCarrito/EliminarProductoEnCarrito/{IdProductoEnCarrito}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return null;
        }

        public async Task<Resena> PostResena(Resena resena)
        {
            var content = new StringContent(JsonConvert.SerializeObject(resena), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Resena", content);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Resena resena2 = JsonConvert.DeserializeObject<Resena>(json_response);
                return resena2;
            }
            return new Resena();
        }

        public async Task<Carrito> PostProductoEnCarrito(string IdUsuario, string IdProducto)
        {
            var response = await _httpClient.PostAsync($"/api/ProductoEnCarrito/AgregarAlCarrito/{IdUsuario}/{IdProducto}", null);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Carrito carrito2 = JsonConvert.DeserializeObject<Carrito>(json_response);
                return carrito2;
            }
            return null;
        }

        public async Task<User> PostUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Usuario", content);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                User user2 = JsonConvert.DeserializeObject<User>(json_response);
                return user2;
            }
            return null;
        }

        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Producto/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<List<Producto>> BuscarProductosPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"/api/Producto?nombre={nombre}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return null;
        }

    }
}
