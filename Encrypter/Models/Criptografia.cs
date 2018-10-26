namespace Ericrypter.Model
{
    using System.ComponentModel;

    public class Criptografia : INotifyPropertyChanged
    {
        private string _textoPlano;
        private string _textoCifrado;
        private string _textoCriptografado;
        private string _textoDescriptografado;

        private string _textoCifradoInvalido;

        #region Propriedades

        public string TextoPlano
        {
            get { return this._textoPlano; }
            set
            {
                this._textoPlano = value;
                this.OnPropertyChanged(nameof(TextoPlano));
                this.OnPropertyChanged(nameof(HasTextoPlano));
            }
        }

        public string TextoCifrado
        {
            get { return this._textoCifrado; }
            set
            {
                this._textoCifrado = value;
                this.OnPropertyChanged(nameof(TextoCifrado));
                this.OnPropertyChanged(nameof(HasTextoCifrado));
            }
        }

        public string TextoCriptografado
        {
            get { return this._textoCriptografado; }
            set
            {
                this._textoCriptografado = value;
                this.OnPropertyChanged(nameof(TextoCriptografado));
            }
        }

        public string TextoDescriptografado
        {
            get { return this._textoDescriptografado; }
            set
            {
                this._textoDescriptografado = value;
                this.OnPropertyChanged(nameof(TextoDescriptografado));
            }
        }

        public bool HasTextoPlano
        {
            get { return !string.IsNullOrEmpty(TextoPlano); }
        }

        public bool HasTextoCifrado
        {
            get { return !string.IsNullOrEmpty(TextoCifrado); }
        }

        public string TextoCifradoInvalido
        {
            get { return this._textoCifradoInvalido; }
            set
            {
                this._textoCifradoInvalido = value;
                this.OnPropertyChanged(nameof(TextoCifradoInvalido));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}