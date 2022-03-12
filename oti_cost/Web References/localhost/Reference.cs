﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace oti_cost.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MainWebServiceSoap", Namespace="http://oti-costing.sy/")]
    public partial class MainWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ShowActiveCenterOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteNQOperationCompleted;
        
        private System.Threading.SendOrPostCallback FillDataTableOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteScalerOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsFoundOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MainWebService() {
            this.Url = global::oti_cost.Properties.Settings.Default.oti_cost_localhost_MainWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ShowActiveCenterCompletedEventHandler ShowActiveCenterCompleted;
        
        /// <remarks/>
        public event ExecuteNQCompletedEventHandler ExecuteNQCompleted;
        
        /// <remarks/>
        public event FillDataTableCompletedEventHandler FillDataTableCompleted;
        
        /// <remarks/>
        public event ExecuteScalerCompletedEventHandler ExecuteScalerCompleted;
        
        /// <remarks/>
        public event IsFoundCompletedEventHandler IsFoundCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://oti-costing.sy/ShowActiveCenter", RequestNamespace="http://oti-costing.sy/", ResponseNamespace="http://oti-costing.sy/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ShowActiveCenter() {
            object[] results = this.Invoke("ShowActiveCenter", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ShowActiveCenterAsync() {
            this.ShowActiveCenterAsync(null);
        }
        
        /// <remarks/>
        public void ShowActiveCenterAsync(object userState) {
            if ((this.ShowActiveCenterOperationCompleted == null)) {
                this.ShowActiveCenterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnShowActiveCenterOperationCompleted);
            }
            this.InvokeAsync("ShowActiveCenter", new object[0], this.ShowActiveCenterOperationCompleted, userState);
        }
        
        private void OnShowActiveCenterOperationCompleted(object arg) {
            if ((this.ShowActiveCenterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ShowActiveCenterCompleted(this, new ShowActiveCenterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://oti-costing.sy/ExecuteNQ", RequestNamespace="http://oti-costing.sy/", ResponseNamespace="http://oti-costing.sy/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExecuteNQ(string qry) {
            object[] results = this.Invoke("ExecuteNQ", new object[] {
                        qry});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteNQAsync(string qry) {
            this.ExecuteNQAsync(qry, null);
        }
        
        /// <remarks/>
        public void ExecuteNQAsync(string qry, object userState) {
            if ((this.ExecuteNQOperationCompleted == null)) {
                this.ExecuteNQOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteNQOperationCompleted);
            }
            this.InvokeAsync("ExecuteNQ", new object[] {
                        qry}, this.ExecuteNQOperationCompleted, userState);
        }
        
        private void OnExecuteNQOperationCompleted(object arg) {
            if ((this.ExecuteNQCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteNQCompleted(this, new ExecuteNQCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://oti-costing.sy/FillDataTable", RequestNamespace="http://oti-costing.sy/", ResponseNamespace="http://oti-costing.sy/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FillDataTable(string query) {
            object[] results = this.Invoke("FillDataTable", new object[] {
                        query});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FillDataTableAsync(string query) {
            this.FillDataTableAsync(query, null);
        }
        
        /// <remarks/>
        public void FillDataTableAsync(string query, object userState) {
            if ((this.FillDataTableOperationCompleted == null)) {
                this.FillDataTableOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFillDataTableOperationCompleted);
            }
            this.InvokeAsync("FillDataTable", new object[] {
                        query}, this.FillDataTableOperationCompleted, userState);
        }
        
        private void OnFillDataTableOperationCompleted(object arg) {
            if ((this.FillDataTableCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FillDataTableCompleted(this, new FillDataTableCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://oti-costing.sy/ExecuteScaler", RequestNamespace="http://oti-costing.sy/", ResponseNamespace="http://oti-costing.sy/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExecuteScaler(string query) {
            object[] results = this.Invoke("ExecuteScaler", new object[] {
                        query});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteScalerAsync(string query) {
            this.ExecuteScalerAsync(query, null);
        }
        
        /// <remarks/>
        public void ExecuteScalerAsync(string query, object userState) {
            if ((this.ExecuteScalerOperationCompleted == null)) {
                this.ExecuteScalerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteScalerOperationCompleted);
            }
            this.InvokeAsync("ExecuteScaler", new object[] {
                        query}, this.ExecuteScalerOperationCompleted, userState);
        }
        
        private void OnExecuteScalerOperationCompleted(object arg) {
            if ((this.ExecuteScalerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteScalerCompleted(this, new ExecuteScalerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://oti-costing.sy/IsFound", RequestNamespace="http://oti-costing.sy/", ResponseNamespace="http://oti-costing.sy/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string IsFound(string data) {
            object[] results = this.Invoke("IsFound", new object[] {
                        data});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void IsFoundAsync(string data) {
            this.IsFoundAsync(data, null);
        }
        
        /// <remarks/>
        public void IsFoundAsync(string data, object userState) {
            if ((this.IsFoundOperationCompleted == null)) {
                this.IsFoundOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsFoundOperationCompleted);
            }
            this.InvokeAsync("IsFound", new object[] {
                        data}, this.IsFoundOperationCompleted, userState);
        }
        
        private void OnIsFoundOperationCompleted(object arg) {
            if ((this.IsFoundCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsFoundCompleted(this, new IsFoundCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ShowActiveCenterCompletedEventHandler(object sender, ShowActiveCenterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ShowActiveCenterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ShowActiveCenterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ExecuteNQCompletedEventHandler(object sender, ExecuteNQCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteNQCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteNQCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void FillDataTableCompletedEventHandler(object sender, FillDataTableCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FillDataTableCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FillDataTableCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ExecuteScalerCompletedEventHandler(object sender, ExecuteScalerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteScalerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteScalerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void IsFoundCompletedEventHandler(object sender, IsFoundCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsFoundCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsFoundCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591