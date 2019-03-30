using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    /// <summary>
    /// 系统唯一值
    /// </summary>
    public static class SystemValue
    {
        /// <summary>
        /// e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        public static string Nuuid()
        {
            return Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  
        /// </summary>
        public static string Uuid()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
        /// </summary>
        public static string Duuid()
        {
            return Guid.NewGuid().ToString("D");
        }
        /// <summary>
        /// {734fd453-a4f8-4c5d-9c98-3fe2d7079760}
        /// </summary>
        public static string Buuid()
        {
            return Guid.NewGuid().ToString("B");
        }
        /// <summary>
        /// (ade24d16-db0f-40af-8794-1e08e2040df3)
        /// </summary>
        public static string Puuid()
        {
            return Guid.NewGuid().ToString("P");
        }
        /// <summary>
        ///  {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}} 
        /// </summary>
        public static string Xuuid()
        {
            return Guid.NewGuid().ToString("X");
        }
    }
}
