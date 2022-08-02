using System;

namespace Entities
{
    public abstract class Electrodomesticos
    {
        public abstract int Peso {get;}
        
    }

    public sealed class TV : Electrodomesticos{
        public override int Peso{
            get{
                return 55;
            }
        }
    }

    public sealed class Cocina : Electrodomesticos{
        public override int Peso{
            get{
                return 108;
            }
        }
    }

    public sealed class Heladera : Electrodomesticos{
        public override int Peso {
            get{
                return 148;
            }
        }
    }
}