    namespace GradoCeroV1.Services
    {
        public class TransposicionService
        {

            private static readonly Dictionary<string, string[]> TonosMayor = new()
            {
                { "C",  new[] { "C", "Dm", "Em", "F", "G", "Am", "Bdim" } },
                { "Db", new[] { "Db", "Ebm", "Fm", "Gb", "Ab", "Bbm", "Cdim" } },
                { "D",  new[] { "D", "Em", "F#m", "G", "A", "Bm", "C#dim" } },
                { "Eb",  new[] { "Eb", "Fm", "Gm", "Ab", "Bb", "Cm", "Ddim" } },
                { "E",  new[] { "E", "F#m", "G#m", "A", "B", "C#m", "D#dim" } },
                { "F",  new[] { "F", "Gm", "Am", "Bb", "C", "Dm", "Edim" } },
                { "F#", new[] { "F#", "G#m", "A#m", "B", "C#", "D#m", "Fdim" } },
                { "G",  new[] { "G", "Am", "Bm", "C", "D", "Em", "F#dim" } },
                { "G#", new[] { "G#", "A#m", "Cm", "Db", "Eb", "Fm", "Gdim" } },
                { "A",  new[] { "A", "Bm", "C#m", "D", "E", "F#m", "G#dim" } },
                { "Bb", new[] { "Bb", "Cm", "Dm", "Eb", "F", "Gm", "Adim" } },
                { "B",  new[] { "B", "C#m", "D#m", "E", "F#", "G#m", "A#dim" } }
            };

            private static readonly Dictionary<string, string[]> TonosMenorArmonico = new()
            {
                { "Cm", new[] { "Cm", "Ddim", "Eb", "Fm", "G", "Ab", "Bdim" } },
                { "C#m", new[] { "C#m", "D#dim", "E", "F#m", "G#", "A", "Cdim" } },
                { "Dm", new[] { "Dm", "Edim", "F", "Gm", "A", "Bb", "C#dim" } },
                { "Ebm", new[] { "Ebm", "Fdim", "Gb", "Abm", "Bb", "B", "Ddim" } },
                { "Em", new[] { "Em", "F#dim", "G", "Am", "B", "C", "D#dim" } },
                { "Fm", new[] { "Fm", "Gdim", "Ab", "Bbm", "C", "Db", "Edim" } },
                { "F#m", new[] { "F#m", "G#dim", "A", "Bm", "C#", "D", "Fdim" } },
                { "Gm", new[] { "Gm", "Adim", "Bb", "Cm", "D", "Eb", "F#dim" } },
                { "G#m", new[] { "G#m", "A#dim", "B", "C#m", "D#", "E", "Gdim" } },
                { "Am", new[] { "Am", "Bdim", "C", "Dm", "E", "F", "G#dim" } },
                { "A#m", new[] { "A#m", "Cdim", "Db", "Ebm", "F", "Gb", "Adim" } },
                { "Bm", new[] { "Bm", "C#dim", "D", "Em", "F#", "G", "A#dim" } }
            };

            private static readonly string[] GradosPorDefecto =
                { "1", "2", "3", "4", "5", "6", "7" };

            public string[] ObtenerAcordes(string tono)
            {
                if (tono == "grados") return GradosPorDefecto;
                if (TonosMayor.TryGetValue(tono, out var acordesMayor)) return acordesMayor;
                if (TonosMenorArmonico.TryGetValue(tono, out var acordesMenor)) return acordesMenor;
                return GradosPorDefecto;
            }

        }
    }
