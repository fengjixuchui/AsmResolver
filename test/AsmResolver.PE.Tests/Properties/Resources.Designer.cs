﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsmResolver.PE.Tests.Properties {
    using System;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {

        private static System.Resources.ResourceManager resourceMan;

        private static System.Globalization.CultureInfo resourceCulture;

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("AsmResolver.PE.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        public static byte[] HelloWorld {
            get {
                object obj = ResourceManager.GetObject("HelloWorld", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_X64 {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_X64", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_MaliciousWin32ResLoop {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_MaliciousWin32ResLoop", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_MaliciousWin32ResDirName {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_MaliciousWin32ResDirName", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_MaliciousWin32ResDirOffset {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_MaliciousWin32ResDirOffset", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_MaliciousWin32ResDataOffset {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_MaliciousWin32ResDataOffset", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] HelloWorld_TablesStream_ExtraData {
            get {
                object obj = ResourceManager.GetObject("HelloWorld_TablesStream_ExtraData", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] SimpleDll {
            get {
                object obj = ResourceManager.GetObject("SimpleDll", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] SimpleDll_Exports {
            get {
                object obj = ResourceManager.GetObject("SimpleDll_Exports", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] TheAnswer_NetFx {
            get {
                object obj = ResourceManager.GetObject("TheAnswer_NetFx", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] TheAnswer_NetCore {
            get {
                object obj = ResourceManager.GetObject("TheAnswer_NetCore", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] SEHSamples {
            get {
                object obj = ResourceManager.GetObject("SEHSamples", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] UnmanagedExports_x64 {
            get {
                object obj = ResourceManager.GetObject("UnmanagedExports_x64", resourceCulture);
                return ((byte[])(obj));
            }
        }

        public static byte[] UnmanagedExports_x32 {
            get {
                object obj = ResourceManager.GetObject("UnmanagedExports_x32", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
