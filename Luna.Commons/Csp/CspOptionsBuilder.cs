using System.Collections.Generic;

namespace ERDF_DispoReseau.Commons.Csp
{
    public class CspOptionsBuilder
    {
        private readonly CspOptions options = new CspOptions();
        
        internal CspOptionsBuilder() { }

        public CspDirectiveBuilder Defaults { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Scripts { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Styles { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Images { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Fonts { get; set; } = new CspDirectiveBuilder();
        public CspDirectiveBuilder Media { get; set; } = new CspDirectiveBuilder();

        internal CspOptions Build()
        {
            options.Defaults = Defaults.Sources;
            options.Scripts = Scripts.Sources;
            options.Styles = Styles.Sources;
            options.Images = Images.Sources;
            options.Fonts = Fonts.Sources;
            options.Media = Media.Sources;
            return options;
        }
    }
    
    public sealed class CspDirectiveBuilder
    {
        internal CspDirectiveBuilder() { }

        internal List<string> Sources { get; set; } = new List<string>();

        public CspDirectiveBuilder AllowSelf() => Allow("'self'");
        public CspDirectiveBuilder AllowNone() => Allow("none");
        public CspDirectiveBuilder AllowAny() => Allow("*");

        public CspDirectiveBuilder Allow(string source)
        {
            Sources.Add(source);
            return this;
        }
    }
}