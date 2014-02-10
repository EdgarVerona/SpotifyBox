using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libspotifydotnet;
using System.IO;
using System.Runtime.InteropServices;

namespace SpotifyBox.Engine
{
    public class SpotifyEngine
    {

        public void SpotifyEngine(string keyfilePath, string cachePath)
        {
            int length = 0;
            byte[] fileData;
            using (FileStream fs = File.OpenRead(keyfilePath))
            {
                length = (int)fs.Length;
                using (BinaryReader reader = new BinaryReader(fs, Encoding.Default, leaveOpen: true))
                {
                    fileData = new byte[length];
                }
            }
            
            IntPtr fileDataPointer = Marshal.AllocHGlobal(length);
            Marshal.Copy(fileData, 0, fileDataPointer, length);

            libspotify.sp_playlist_callbacks callbacks = new libspotify.sp_playlist_callbacks();
            callbacks.connection_error = Marshal.GetFunctionPointerForDelegate(fn_connection_error_delegate);

            IntPtr sessionPointer;
            libspotify.sp_session_config config = new libspotify.sp_session_config();
            config.api_version = libspotify.SPOTIFY_API_VERSION;
            config.application_key = fileDataPointer;
            config.application_key_size = length;
            config.cache_location = cachePath;
            config.callbacks = ;
            config.compress_playlists = true;
            config.dont_save_metadata_for_playlists = false;
            config.initially_unload_playlists = true;
            config.settings_location = cachePath;
            config.user_agent = "SpotifyBox.Engine";
            
            libspotify.sp_session_create(ref config, out sessionPointer);

            // Call unmanaged code
            Marshal.FreeHGlobal(fileDataPointer);

            
        }
    }
}
