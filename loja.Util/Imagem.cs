using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.IO;

namespace loja.Util
{
    public class Imagem
    {
        private Image Image;
        private HiddenField Hidden;
        private FileUpload FileUpload;

        private string Path;
        private string Arquivo;

        public Imagem(FileUpload FileUpload, string Path, string Arquivo)
        {
            this.FileUpload = FileUpload;
            this.Path = Path;
            this.Arquivo = Arquivo;
        }

        public Imagem(FileUpload FileUpload, HiddenField Hidden, string Path, string Arquivo)
        {
            this.FileUpload = FileUpload;
            this.Hidden = Hidden;
            this.Path = Path;
            this.Arquivo = Arquivo;
        }

        public Imagem(Image Image, HiddenField Hidden, string Path, string Arquivo)
        {
            this.Image = Image;
            this.Hidden = Hidden;
            this.Path = Path;
            this.Arquivo = Arquivo;
        }

        public void Carregar()
        {
            if (Image == null)
                throw new Exception("Esperado objeto Image.");
            if (Hidden == null)
                throw new Exception("Esperado objeto Hidden.");
            if (Path == String.Empty)
                throw new Exception("Esperado caminho da imagem.");
            if (Arquivo == String.Empty)
                throw new Exception("Esperado Arquivo.");

            Image.Visible = true;
            Image.ImageUrl = Path + Arquivo;
            Hidden.Value = Arquivo;
        }

        public void Upload()
        {
            if (FileUpload == null)
                throw new Exception("Esperado objeto FileUpload.");
            if (Path == String.Empty)
                throw new Exception("Esperado caminho da imagem.");
            if (Arquivo == String.Empty)
                throw new Exception("Esperado Arquivo.");

            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            if (Hidden != null)
            {
                if (File.Exists(Path + Hidden.Value))
                    File.Delete(Path + Hidden.Value);
            }

            FileUpload.PostedFile.SaveAs(Path + Arquivo);   
        }
    }
}