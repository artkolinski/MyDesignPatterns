using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Singleton
{
    public class Program
    {
        static void Main()
        {
        }
        public static void Serialize(ShoppingList shoppingList)
        {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            FileStream fs = new FileStream("D:/file.xml", FileMode.OpenOrCreate);
            binaryFmt.Serialize(fs, shoppingList);
            fs.Close();
        }
        public static ShoppingList Deserialize()
        {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            FileStream fs = new FileStream("D:/file.xml", FileMode.OpenOrCreate);
            ShoppingList deserializedShoppingList = (ShoppingList)binaryFmt.Deserialize(fs);
            fs.Close();
            return deserializedShoppingList;
        }
    }
}
