﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MathsLibrary_MultipleEndpoints_Different_" +
        "Adress")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MathsLibrary_MultipleEndpoints_Different_Adress.IMathsOperations")]
    public interface IMathsOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        int Add(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        int Multiply(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        System.Threading.Tasks.Task<int> MultiplyAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Substract", ReplyAction="http://tempuri.org/IMathsOperations/SubstractResponse")]
        int Substract(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Substract", ReplyAction="http://tempuri.org/IMathsOperations/SubstractResponse")]
        System.Threading.Tasks.Task<int> SubstractAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Divide", ReplyAction="http://tempuri.org/IMathsOperations/DivideResponse")]
        float Divide(float x, float y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Divide", ReplyAction="http://tempuri.org/IMathsOperations/DivideResponse")]
        System.Threading.Tasks.Task<float> DivideAsync(float x, float y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType GetDataUsingDataContract(WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType> GetDataUsingDataContractAsync(WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMathsOperationsChannel : WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.IMathsOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MathsOperationsClient : System.ServiceModel.ClientBase<WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.IMathsOperations>, WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.IMathsOperations {
        
        public MathsOperationsClient() {
        }
        
        public MathsOperationsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MathsOperationsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MathsOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MathsOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int x, int y) {
            return base.Channel.Add(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int x, int y) {
            return base.Channel.AddAsync(x, y);
        }
        
        public int Multiply(int x, int y) {
            return base.Channel.Multiply(x, y);
        }
        
        public System.Threading.Tasks.Task<int> MultiplyAsync(int x, int y) {
            return base.Channel.MultiplyAsync(x, y);
        }
        
        public int Substract(int x, int y) {
            return base.Channel.Substract(x, y);
        }
        
        public System.Threading.Tasks.Task<int> SubstractAsync(int x, int y) {
            return base.Channel.SubstractAsync(x, y);
        }
        
        public float Divide(float x, float y) {
            return base.Channel.Divide(x, y);
        }
        
        public System.Threading.Tasks.Task<float> DivideAsync(float x, float y) {
            return base.Channel.DivideAsync(x, y);
        }
        
        public WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType GetDataUsingDataContract(WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType> GetDataUsingDataContractAsync(WebServiceClientSOAP.MathsLibrary_MultipleEndpoints_Different_Adress.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
