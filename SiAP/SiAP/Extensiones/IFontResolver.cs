using PdfSharp.Fonts;
using System;
using System.IO;

namespace SiAP.Extensions
{
    public class CustomFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Normalizar el nombre de la fuente
            string fontName = familyName.ToLower();

            // Determinar el estilo
            if (isBold && isItalic)
                return new FontResolverInfo($"{fontName}-bolditalic");
            else if (isBold)
                return new FontResolverInfo($"{fontName}-bold");
            else if (isItalic)
                return new FontResolverInfo($"{fontName}-italic");
            else
                return new FontResolverInfo($"{fontName}-regular");
        }

        public byte[] GetFont(string faceName)
        {
            // Mapeo de fuentes a recursos embebidos o rutas del sistema
            switch (faceName.ToLower())
            {
                // Arial Regular
                case "arial-regular":
                    return LoadFontFromSystem("arial.ttf");

                // Arial Bold
                case "arial-bold":
                    return LoadFontFromSystem("arialbd.ttf");

                // Arial Italic
                case "arial-italic":
                    return LoadFontFromSystem("ariali.ttf");

                // Arial Bold Italic
                case "arial-bolditalic":
                    return LoadFontFromSystem("arialbi.ttf");

                default:
                    // Fuente por defecto
                    return LoadFontFromSystem("arial.ttf");
            }
        }

        private byte[] LoadFontFromSystem(string fontFileName)
        {
            // Ruta de fuentes de Windows
            string fontPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                fontFileName
            );

            if (File.Exists(fontPath))
            {
                return File.ReadAllBytes(fontPath);
            }

            // Si no encuentra Arial, intenta con una fuente alternativa
            string[] alternativas = { "calibri.ttf", "segoeui.ttf", "tahoma.ttf" };
            foreach (var alt in alternativas)
            {
                string altPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                    alt
                );
                if (File.Exists(altPath))
                {
                    return File.ReadAllBytes(altPath);
                }
            }

            throw new FileNotFoundException($"No se pudo cargar la fuente: {fontFileName}");
        }
    }
}