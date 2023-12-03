using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root); //yeni dosya ve kayıt edileceği adres
        }

        public string Upload(IFormFile? file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //Seçilen dosya uzantısı
                string guid = GuidHelper.CreateGuid(); //Eşşiz bir dosya ismi oluşturdu
                string filePath = guid + extension; //Dosya adı ve uzantısı

                //(root + newPath)=>Oluşturulacak dosyanın yolu ve adı
                using (FileStream fileStream = File.Create(root + filePath))
                {
                    //Yukarıda gelen IFromFile türündeki file dosyasının kopyalanacağı yol
                    file.CopyTo(fileStream);
                    fileStream.Flush();//Arabellekten silme işlemi
                    return filePath; //Sql servere dosya yollanırken adıyla eklenmesi için dosyanın tam adı döndürülüyor

                }
            }
            return null;
        }
    }
}

//IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır