using Packets.Core.Utilities;
using Packets.Server.Game.Enums;

namespace Packets.Server.Game.Structures
{
    public class PublicItem
    {
        public PublicItem()
        {
            UniqueIdentifier = new UniqueId(UniqueIdentifierType.Item);
            Item = new ItemApiModel();
            Position = new Vector3();
        }

        public UniqueId UniqueIdentifier { get; set; }
        public ItemApiModel Item { get; set; }
        public Vector3 Position { get; set; }

        public void Read(FormationPackage formationPackage)
        {
            UniqueIdentifier.Read(formationPackage);
            formationPackage.ReadBytes(4);

            Item.Read(formationPackage);

            Position.Read(formationPackage);
            formationPackage.ReadBytes(4);
        }

        public void Write(FormationPackage formationPackage)
        {
            UniqueIdentifier.Write(formationPackage);
            formationPackage.AddZeroBytes(4);

            Item.Write(formationPackage);

            Position.Write(formationPackage);
            formationPackage.AddZeroBytes(4);
        }
    }
}
