﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Envios.ReferenciaDeServicioDeCorreoDeASAE {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.asae.com.mx", ConfigurationName="ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap")]
    public interface CorreoSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento host del espacio de nombres http://www.asae.com.mx no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoMetPrivado", ReplyAction="*")]
        Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse CorreoMetPrivado(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoMetPrivado", ReplyAction="*")]
        System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse> CorreoMetPrivadoAsync(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento host del espacio de nombres http://www.asae.com.mx no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeTickets", ReplyAction="*")]
        Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse CorreoAsaeTickets(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeTickets", ReplyAction="*")]
        System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse> CorreoAsaeTicketsAsync(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoMetPrivadoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoMetPrivado", Namespace="http://www.asae.com.mx", Order=0)]
        public Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequestBody Body;
        
        public CorreoMetPrivadoRequest() {
        }
        
        public CorreoMetPrivadoRequest(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoMetPrivadoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string host;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int puerto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string contra;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string body;
        
        public CorreoMetPrivadoRequestBody() {
        }
        
        public CorreoMetPrivadoRequestBody(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.contra = contra;
            this.Email = Email;
            this.from = from;
            this.Subject = Subject;
            this.body = body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoMetPrivadoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoMetPrivadoResponse", Namespace="http://www.asae.com.mx", Order=0)]
        public Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponseBody Body;
        
        public CorreoMetPrivadoResponse() {
        }
        
        public CorreoMetPrivadoResponse(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoMetPrivadoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CorreoMetPrivadoResult;
        
        public CorreoMetPrivadoResponseBody() {
        }
        
        public CorreoMetPrivadoResponseBody(string CorreoMetPrivadoResult) {
            this.CorreoMetPrivadoResult = CorreoMetPrivadoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeTicketsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeTickets", Namespace="http://www.asae.com.mx", Order=0)]
        public Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequestBody Body;
        
        public CorreoAsaeTicketsRequest() {
        }
        
        public CorreoAsaeTicketsRequest(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeTicketsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string host;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int puerto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string contra;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string EmailCopia;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string body;
        
        public CorreoAsaeTicketsRequestBody() {
        }
        
        public CorreoAsaeTicketsRequestBody(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.contra = contra;
            this.Email = Email;
            this.EmailCopia = EmailCopia;
            this.from = from;
            this.Subject = Subject;
            this.body = body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeTicketsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeTicketsResponse", Namespace="http://www.asae.com.mx", Order=0)]
        public Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponseBody Body;
        
        public CorreoAsaeTicketsResponse() {
        }
        
        public CorreoAsaeTicketsResponse(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeTicketsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CorreoAsaeTicketsResult;
        
        public CorreoAsaeTicketsResponseBody() {
        }
        
        public CorreoAsaeTicketsResponseBody(string CorreoAsaeTicketsResult) {
            this.CorreoAsaeTicketsResult = CorreoAsaeTicketsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CorreoSoapChannel : Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CorreoSoapClient : System.ServiceModel.ClientBase<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap>, Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap {
        
        public CorreoSoapClient() {
        }
        
        public CorreoSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CorreoSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CorreoSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CorreoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap.CorreoMetPrivado(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest request) {
            return base.Channel.CorreoMetPrivado(request);
        }
        
        public string CorreoMetPrivado(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest inValue = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest();
            inValue.Body = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse retVal = ((Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap)(this)).CorreoMetPrivado(inValue);
            return retVal.Body.CorreoMetPrivadoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse> Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap.CorreoMetPrivadoAsync(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest request) {
            return base.Channel.CorreoMetPrivadoAsync(request);
        }
        
        public System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoResponse> CorreoMetPrivadoAsync(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest inValue = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequest();
            inValue.Body = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoMetPrivadoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            return ((Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap)(this)).CorreoMetPrivadoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap.CorreoAsaeTickets(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest request) {
            return base.Channel.CorreoAsaeTickets(request);
        }
        
        public string CorreoAsaeTickets(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest inValue = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest();
            inValue.Body = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse retVal = ((Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap)(this)).CorreoAsaeTickets(inValue);
            return retVal.Body.CorreoAsaeTicketsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse> Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap.CorreoAsaeTicketsAsync(Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest request) {
            return base.Channel.CorreoAsaeTicketsAsync(request);
        }
        
        public System.Threading.Tasks.Task<Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsResponse> CorreoAsaeTicketsAsync(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest inValue = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequest();
            inValue.Body = new Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoAsaeTicketsRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            return ((Envios.ReferenciaDeServicioDeCorreoDeASAE.CorreoSoap)(this)).CorreoAsaeTicketsAsync(inValue);
        }
    }
}
