using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    /// <summary>
    /// A class to manage a hash table for objects indexed off a string key.
    /// </summary>
    public class ChainHash
    {
       /// <summary>
       /// Hash function for objects placed in the hash table.
       /// Note: The key being hashed in this situation is a string that is not going to be stored inside the 
       /// hashed data object.  C# does not allow string or String to be inherited from, so the hash
       /// function is being placed within the hashtable class.
       /// djb2:
       /// This algorithm (k= 33) was first reported by Dan Bernstein many years ago in comp.lang.c.
       /// Another version of this algorithm (now favored by Bernstein) uses xor: hash(i) = hash(i - 1) * 33 ^ str[i];
       /// The magic of number 33 (why it works better than many other constants,
       /// prime or not) has never been adequately explained.
       /// </summary>
       /// <param name="str"></param>
       /// <returns>hash number for this string</returns>
        public int Hash(string str)
        {
            int hash = 5381;

            foreach (char chr in str)
            {
                hash = ((hash << 5) + hash) + (int)chr; /* hash * 33 + chr */
            }

            return hash;
        }
        /// <summary>
        /// A class unique to the hash table to create nodes for the hash table lists.
        /// </summary>
        protected class ChainObj
        {
            /// <summary>
            /// String key used to place the object in the table
            /// </summary>
            public string Key { get; protected set; }
            /// <summary>
            /// Object containing the data referenced by the table.
            /// </summary>
            public Object Data { get; set; }
            /// <summary>
            /// Next object in the list, if any.
            /// </summary>
            public ChainObj Next { get; set; }
            /// <summary>
            /// Construct the object with its key and data.
            /// </summary>
            /// <param name="key">string key</param>
            /// <param name="obj">data</param>
            public ChainObj(string key, Object obj)
            {
                Key = key;
                Data = obj;
            }
        }
        /// <summary>
        /// Actual hash table
        /// </summary>
        protected ChainObj[] table;
        /// <summary>
        /// Set this default to a prime number
        /// </summary>
        protected const int DefaultSize = 101;
        protected const int MinSize = 11;
        protected const int MaxSize = 5003;
        /// <summary>
        /// Default constructor that sets the size of the table to DefaultSize
        /// </summary>
        public ChainHash()
        {
            table = new ChainObj[DefaultSize];
        }
        /// <summary>
        /// Constructor that specifies the hash table size
        /// </summary>
        /// <param name="size"></param>
        public ChainHash(int size)
        {
            if (size < MinSize)
                throw new ArgumentOutOfRangeException("Size must be at least " + MinSize.ToString());
            if  (size > MaxSize)
                throw new ArgumentOutOfRangeException("Size must be no greater than " + MaxSize.ToString());
            table = new ChainObj[size];
        }
        /// <summary>
        /// Insert an object into the hash table.
        /// If the table has no items at this hash location, put it there, 
        /// otherwise, add it to the beginning of the list.
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="obj">data</param>
        public void Insert(string key, Object obj)
        {
            ChainObj newObj = new ChainObj(key, obj);
            int hash = key.GetHashCode();
            ChainObj hashObj = table[hash];
            if (hashObj == null)
                table[hash] = newObj;
            else
            {
                newObj = hashObj.Next;
                table[hash] = newObj;
            }
        }
        /// <summary>
        /// Find the object indicated by the string key by first looking
        /// at the hash location in the table, if the slot is occupied, 
        /// verify it has the same key, if not, walk down the list until you
        /// find the same key or the end of the list.  Return the object
        /// if found, or null otherwise.
        /// </summary>
        /// <param name="key">string key</param>
        /// <returns>object if found, null otherwise</returns>
        public Object Find(string key)
        {
            int hash = key.GetHashCode();
            ChainObj obj = table[hash];
            if (obj == null)
                return default(Object);
            else
            {
                while (obj != null)
                {
                    if (obj.Key.Equals(key))
                        return obj.Data;
                    obj = obj.Next;
                }
                return default(Object);
            }
        }
        /// <summary>
        /// Remove the item identified by key from the hash table.
        /// First look at the index identified by it's hash in the table,
        /// if the keys match, remove the object from the list.  Otherwise,
        /// walk down the list until you find the key, then remove it.
        /// If the key is not found, do nothing.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            int hash = key.GetHashCode();
            ChainObj obj = table[hash];
            if (obj == null)
                return;
            else if (obj.Key.Equals(key))
            {
                table[hash] = obj.Next;
            }
            else
            {
                ChainObj prev = obj;
                while (prev.Next != null)
                {
                    obj = prev.Next;
                    if (obj.Key.Equals(key))
                    {
                        prev.Next = obj.Next; // remove the object from the list
                        return;
                    }
                    prev = obj.Next;
                }
            }
        }
    }
}
