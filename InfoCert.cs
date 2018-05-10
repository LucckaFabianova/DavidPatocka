using System;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.IO;
using System.Security.Cryptography.X509Certificates;
 
 
namespace ConsoleAppTestEncrypt_2 {
    class CertInfo {
 
 
 
        //Reads a file.
        internal static byte [] ReadFile ( string _fileName ) {
            FileStream f = new FileStream ( _fileName, FileMode.Open, FileAccess.Read );
            int size = ( int ) f.Length;
            byte [] data = new byte [ size ];
            size = f.Read ( data, 0, size );
            f.Close ( );
            return data;
        }
 
 
        static void Main ( string [] args ) {
 
 
            ////Test for correct number of arguments.
            //if ( args.Length < 1 ) {
            //    Console.WriteLine ( "Usage: CertInfo <filename>" );
 
            //    return;
            //}
 
 
            try {
                X509Certificate2 x509 = new X509Certificate2 ( @"C:\\Users\\noent\\Desktop\\EncryptData\\EncryptData\\ConsoleAppTestEncrypt_2\\bin\\Debug\\Enc.cer" );
 
                string cst = @"C:\\Users\\noent\\Desktop\\EncryptData\\EncryptData\\ConsoleAppTestEncrypt_2\\bin\\Debug\\Enc.cer";
 
                //Create X509Certificate2 object from .cer file.
                byte [] rawData = ReadFile ( cst );
 
                x509.Import ( rawData );
 
                //Print to console information contained in the certificate.
                Console.WriteLine ( "{0}Subject: {1}{0}", Environment.NewLine, x509.Subject );
                Console.WriteLine ( "{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer );
                Console.WriteLine ( "{0}Version: {1}{0}", Environment.NewLine, x509.Version );
                Console.WriteLine ( "{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore );
                Console.WriteLine ( "{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter );
                Console.WriteLine ( "{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint );
                Console.WriteLine ( "{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber );
                Console.WriteLine ( "{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName );
                Console.WriteLine ( "{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format ( true ) );
                Console.WriteLine ( "{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length );
                Console.WriteLine ( "{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString ( true ) );
 
                Console.WriteLine ( "{0}Certificate to XML String: {1}{0}", Environment.NewLine, x509.PublicKey.Key.ToXmlString ( false ) );
                Console.ReadLine ( );
                //Add the certificate to a X509Store.
                X509Store store = new X509Store ( );
                store.Open ( OpenFlags.MaxAllowed );
                store.Add ( x509 );
                store.Close ( );
            }
 
            catch ( DirectoryNotFoundException ) {
                Console.WriteLine ( "Error: The directory specified could not be found." );
                //Console.ReadLine ( );
            }
            catch ( IOException ) {
                Console.WriteLine ( "Error: A file in the directory could not be accessed." );
                //Console.ReadLine ( );
            }
            catch ( NullReferenceException ) {
                Console.WriteLine ( "File must be a .cer file. Program does not have access to that type of file." );
                //Console.ReadLine ( );
            }
        }
 
    }
}
 
