using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;

namespace duckshmem_dll
{
    public static class Duck_Mem
    {
        const uint memSize = 0x800000;

        public enum types : byte
        {
            INT, 
            UINT,
            CHAR,
            UCHAR,
            SHORT,
            USHORT,
            LONG,
            ULONG
        };

        // PID-based version: avoids searching the process by name (which fails with 0 or multiple ducks open)
        public static void Write_DuckShmem(int duck_pid, long offset, object newValue, types type)
        {
            using (MemoryMappedFile MemoryMapFile = MemoryMappedFile.OpenExisting($"duckstation_{duck_pid}", MemoryMappedFileRights.Write))
            using (MemoryMappedViewAccessor Shmem = MemoryMapFile.CreateViewAccessor(0, memSize, MemoryMappedFileAccess.Write))
            {
                Shmem_Manager(Shmem, offset, newValue, type, false);
            }
        }

        public static object Read_DuckShmem(int duck_pid, long offset, types type)
        {
            using (MemoryMappedFile MemoryMapFile = MemoryMappedFile.OpenExisting($"duckstation_{duck_pid}", MemoryMappedFileRights.Read))
            using (MemoryMappedViewAccessor Shmem = MemoryMapFile.CreateViewAccessor(0, memSize, MemoryMappedFileAccess.Read))
            {
                return Shmem_Manager(Shmem, offset, null, type, true);
            }
        }

        public static void Write_DuckShmem(MemoryMappedViewAccessor optionalPtr, string duck_filename, long offset, object newValue, types type)
        {


            string fullName = GET_DUCK(duck_filename);

            if (optionalPtr == null)
            {
                using (MemoryMappedFile MemoryMapFile = MemoryMappedFile.OpenExisting(fullName, MemoryMappedFileRights.Write))
                using (MemoryMappedViewAccessor Shmem = MemoryMapFile.CreateViewAccessor(0, memSize, MemoryMappedFileAccess.Write))
                {
                    Shmem_Manager(Shmem, offset, newValue, type, false);
                }
            }
            else
            {
                Shmem_Manager(optionalPtr, offset, newValue, type, false);
            }

        }




        public static object Read_DuckShmem(MemoryMappedViewAccessor optionalPtr, string duck_filename, long offset, types type)
        {

            string fullName = GET_DUCK(duck_filename);


            if (optionalPtr == null)
            {
                using (MemoryMappedFile MemoryMapFile = MemoryMappedFile.OpenExisting(fullName, MemoryMappedFileRights.Read))
                using (MemoryMappedViewAccessor Shmem = MemoryMapFile.CreateViewAccessor(0, memSize, MemoryMappedFileAccess.Read))
                {
                    return Shmem_Manager(Shmem, offset, null, type, true);
                }
            }
            else
            {
                return Shmem_Manager(optionalPtr, offset, null, type, true);
            }
        }





        public static MemoryMappedViewAccessor GET_Shmem(string duck_filename)
        {
            string fullName = GET_DUCK(duck_filename);

            MemoryMappedFile MemoryMapFile = MemoryMappedFile.OpenExisting(fullName, MemoryMappedFileRights.ReadWrite);

            MemoryMappedViewAccessor Shmem = MemoryMapFile.CreateViewAccessor(0, memSize);

            return Shmem;
        }

        public static string GET_DUCK(string duck_filename)
        {

            Process[] duck_process = Process.GetProcessesByName(duck_filename);

            if (duck_process.Length == 0)
                throw new InvalidOperationException("Duckstation is not open.");
            else if (duck_process.Length > 1)
                throw new InvalidOperationException("Too many ducks are open, please close the extra ones");

            int pid = duck_process[0].Id;

            return $"duckstation_{pid}";

         }

       
        public static object Shmem_Manager(MemoryMappedViewAccessor Shmem ,long offset, object newValue, types type, bool read)
        {
            // this could just be offset - 0x80000000, but masking avoids ever getting a negative value
            offset = offset & 0xffffff;

            if (offset >= memSize)
                throw new InvalidOperationException("offset is out of range!");

   
            switch (type)
                {
                    case types.INT:
                        {
                            if (read)
                            return Shmem.ReadInt32(offset);
                            else
                                Shmem.Write(offset, Convert.ToInt32(newValue));
                            break;
                        }
                    case types.UINT:
                        {
                            if (read)
                            return Shmem.ReadUInt32(offset);
                            else
                                Shmem.Write(offset, Convert.ToUInt32(newValue));
                            break;
                        }
                    case types.CHAR:
                        {
                            if (read)
                            return Shmem.ReadSByte(offset);
                            else
                                Shmem.Write(offset, Convert.ToSByte(newValue));
                            break;
                        }
                    case types.UCHAR:
                        {
                            if (read)
                            return Shmem.ReadByte(offset);
                            else
                                Shmem.Write(offset, Convert.ToByte(newValue));
                            break;
                        }
                    case types.SHORT:
                        {
                            if (read)
                            return Shmem.ReadInt16(offset);
                            else
                                Shmem.Write(offset, Convert.ToInt16(newValue));
                            break;
                        }
                    case types.USHORT:
                        {
                            if (read)
                            return Shmem.ReadUInt16(offset);
                            else
                                Shmem.Write(offset, Convert.ToUInt16(newValue));
                            break;
                        }
                    case types.LONG:
                        {
                            if (read)
                            return Shmem.ReadInt64(offset);
                            else
                                Shmem.Write(offset, Convert.ToInt64(newValue));
                            break;
                        }
                    case types.ULONG:
                        {
                            if (read)
                            return Shmem.ReadUInt64(offset);
                            else
                                Shmem.Write(offset, Convert.ToUInt64(newValue));
                            break;
                        }

                    default:
                        throw new InvalidOperationException("invalid type!");
                }
            

            return null;
        }

    }
}
