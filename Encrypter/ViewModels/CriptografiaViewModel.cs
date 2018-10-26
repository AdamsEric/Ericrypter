namespace Ericrypter.ViewModels
{
    using Ericrypter.Commands;
    using Ericrypter.Model;
    using System;
    using System.Linq;

    public class CriptografiaViewModel
    {
        public Criptografia Criptografia { get; set; }
        public CriptografiaCommand CriptografarCommand { get; set; }
        public CriptografiaCommand DescriptografarCommand { get; set; }

        public CriptografiaViewModel()
        {
            Criptografia = new Criptografia();

            CriptografarCommand = new CriptografiaCommand(Criptografar);
            DescriptografarCommand = new CriptografiaCommand(Descriptografar);
        }

        #region Métodos

        /// <summary>
        /// Aplica a criptografia na mensagem requisitada
        /// </summary>
        public void Criptografar()
        {
            string textoCifrado = Criptografia.TextoPlano;

            textoCifrado = InverterCaracteres(textoCifrado); // Inverte os caracteres digitados

            int numeroAplicacoes = 16;
            do
            {
                textoCifrado = CifraDeCeseric(textoCifrado, 5); // Aplica a cifra de Ceseric
                textoCifrado = CifraDeVigeneric(textoCifrado, "eric220292"); // Aplica a cifra de Vigeneric
            } while (--numeroAplicacoes != 0);

            textoCifrado = "x" + textoCifrado + "x"; // Inclui caracteres de validação

            Criptografia.TextoCriptografado = textoCifrado;
        }

        /// <summary>
        /// Aplica a descriptografia na mensagem requisitada
        /// </summary>
        public void Descriptografar()
        {
            Criptografia.TextoCifradoInvalido = " ";

            try
            {
                string textoPlano = Criptografia.TextoCifrado;

                textoPlano = textoPlano.Substring(1, Criptografia.TextoCifrado.Length - 1).Substring(0, Criptografia.TextoCifrado.Length - 2); //Remove caracteres de validação

                int numeroAplicacoes = 16;
                do
                {
                    textoPlano = CifraDeVigeneric(textoPlano, "eric220292", false); //Resolve a cifra de Vigeneric
                    textoPlano = CifraDeCeseric(textoPlano, 5, false); // Resolve a cifra de César
                } while (--numeroAplicacoes != 0);

                textoPlano = InverterCaracteres(textoPlano); // Desinverte os caracteres

                Criptografia.TextoDescriptografado = textoPlano;
            }
            catch (Exception ex)
            {
                Criptografia.TextoCifradoInvalido = "Texto cifrado inválido. Informe um texto criptografado por esta ferramenta.";
            }


        }

        /// <summary>
        /// Aplica a Cifra de Ceseric na mensagem requisitada (Cifra de Cesár modificada - não possui restrição pelo alfabeto); 
        /// </summary>
        /// <param name="mensagem">Mensagem a ser aplicada a cifra</param>
        /// <param name="chave">Passo a ser avançado com base na tabela ASCII extendida</param>
        /// /// <param name="aplicar">Indica se o método deve aplicar a cifra ('false' para resolver a cifra)</param>
        /// <returns>Mensagem cifrada</returns>
        private string CifraDeCeseric(string mensagem, int chave = 1, bool aplicar = true)
        {
            string mensagemCifrada = "";

            if (aplicar)
            {
                mensagem.ToCharArray().ToList().ForEach(e => mensagemCifrada += Convert.ToString(Convert.ToChar(e + chave)));
            }
            else
            {
                mensagem.ToCharArray().ToList().ForEach(e => mensagemCifrada += Convert.ToString(Convert.ToChar(e - chave)));
            }

            return mensagemCifrada;
        }

        /// <summary>
        /// Inverte os caracteres da mensagem requisitada
        /// </summary>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        private string InverterCaracteres(string mensagem)
        {
            string mensagemInvertida = "";

            mensagem.ToCharArray().ToList().ForEach(e => mensagemInvertida = Convert.ToString(e) + mensagemInvertida);

            return mensagemInvertida;
        }

        /// <summary>
        /// Aplica a Cifra de Vigeneric na mensagem requisitada (Cifra semelhante a de Vigenére, porém sem tabela definida, seguindo sequência ASCII Extendida); 
        /// </summary>
        /// <param name="mensagem">Mensagem a ser aplicada a cifra</param>
        /// <param name="chave">Passo a ser avançado com base na tabela ASCII extendida</param>
        /// <param name="aplicar">Indica se o método deve aplicar a cifra ('false' para resolver a cifra)</param>
        /// <returns>Mensagem cifrada</returns>
        private string CifraDeVigeneric(string mensagem, string chave, bool aplicar = true)
        {
            string mensagemCifrada = "";

            if (aplicar)
            {
                for (int i = 0; i < mensagem.Length; i++)
                {
                    mensagemCifrada += Convert.ToString(Convert.ToChar(mensagem[i] + chave[i % chave.Length]));
                }
            }
            else
            {
                for (int i = 0; i < mensagem.Length; i++)
                {
                    mensagemCifrada += Convert.ToString(Convert.ToChar(mensagem[i] - chave[i % chave.Length]));
                }
            }

            return mensagemCifrada;
        }

        #endregion
    }
}
