using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaUsuario : ICUAlta<Usuario>{

        public IRepositorioUsuarios Repo { get; set; }
        public CUAltaUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public void Alta(Usuario obj) {
            byte[] key = EncryptionUtility.GenerateRandomKey();
            byte[] iv = EncryptionUtility.GenerateRandomIV();
            obj.ContraseniaEncriptada = EncryptionUtility.EncryptString(obj.Contraseña, key, iv);
            Repo.Create(obj);
        }
    }

    public class EncryptionUtility {
        public static byte[] GenerateRandomKey() {
            using var aes = Aes.Create();
            aes.GenerateKey();
            return aes.Key;
        }

        public static byte[] GenerateRandomIV() {
            using var aes = Aes.Create();
            aes.GenerateIV();
            return aes.IV;
        }

        public static string EncryptString(string plainText, byte[] key, byte[] iv) {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                using (var swEncrypt = new StreamWriter(csEncrypt)) {
                    swEncrypt.Write(plainText);
                }
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }
}
