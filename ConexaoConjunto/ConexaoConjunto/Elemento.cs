using System;
using System.Collections.Generic;
using System.Collections;

namespace Conexao
{
    public class Elemento
    {
        private int numero;
        private List<Elemento> conexoes;
        private string cor = "Não visitado";

        public Elemento(int numero)
        {
            conexoes = new List<Elemento>();
            setNumero(numero);
        }

        public List<Elemento> getConexoes()
        {
            return conexoes;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public string getCor()
        {
            return cor;
        }

        public void setCor(string cor)
        {
            this.cor = cor;
        }

        public void addConexao(Elemento elemento)
        {
            this.conexoes.Add(elemento);
        }

    }
}