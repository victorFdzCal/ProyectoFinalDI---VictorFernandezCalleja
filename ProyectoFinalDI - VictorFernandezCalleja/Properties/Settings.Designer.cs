﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalDI___VictorFernandezCalleja.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\victo\\source\\repos\\P" +
            "royectoFinalDI - VictorFernandezCalleja\\ProyectoFinalDI - VictorFernandezCalleja" +
            "\\ProjectDB\\SqlData\\LocalImages\\LocalImagesDB\\DB_Local_Images.mdf;Integrated Secu" +
            "rity=True")]
        public string DB_Local_ImagesConnectionString {
            get {
                return ((string)(this["DB_Local_ImagesConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("server=localhost;user id=root;password=toor;database=projectdb")]
        public string projectdbConnectionString {
            get {
                return ((string)(this["projectdbConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("server=localhost;user id=victor;password=victor;database=projectdb;persistsecurit" +
            "yinfo=True")]
        public string projectdbConnectionString1 {
            get {
                return ((string)(this["projectdbConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\victo\\source\\repos\\P" +
            "royectoFinalDI - VictorFernandezCalleja\\ProyectoFinalDI - VictorFernandezCalleja" +
            "\\ProjectDB\\SqlData\\Facturas\\FacturasDB\\FacturasDB.mdf;Integrated Security=True")]
        public string FacturasDBConnectionString {
            get {
                return ((string)(this["FacturasDBConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("server=infsalinas.sytes.net;user id=usuario;password=dam1234;port=5306;database=p" +
            "rojectdb")]
        public string projectdbConnectionString2 {
            get {
                return ((string)(this["projectdbConnectionString2"]));
            }
        }
    }
}
