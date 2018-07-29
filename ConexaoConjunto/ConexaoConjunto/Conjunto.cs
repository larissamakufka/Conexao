using System;
using System.Collections.Generic;

namespace Conexao
{
    public class Conjunto
    {
        private int qtdTotalElementos;
        private int qtdAtualElementos;
        private List<Elemento> Q;
        private List<Elemento> elementos;

        public const string NAO_VISITADO = "Não visitado";
        public const string VISITADO = "visitado";
        public const string VISITADO_NOS = "Visitado e seus elementos visitados";

        public Conjunto(int qtdTotalElementos)
        {
            if (qtdTotalElementos == 0)
                throw new System.Exception("Valor 0 é inválido para quantidade de elementos");
            this.qtdTotalElementos = qtdTotalElementos;
            elementos = new List<Elemento>();
        }

        public void Conectar(int elementoA, int elementoB)
        {
            Boolean existeA = false, existeB = false;
            for (int i = 0; i < elementos.Count; i++)
            {
                if (!existeA && elementos[i].getNumero().Equals(elementoA))
                {
                    existeA = true;
                }
                if (!existeB && elementos[i].getNumero().Equals(elementoB))
                {
                    existeB = true;
                }
            }

            Elemento vB = null;
            if (!existeB)
            {
                vB = new Elemento(elementoB);
                qtdAtualElementos++;
                if (qtdAtualElementos > qtdTotalElementos)
                {
                    throw new System.Exception("Limite de quantidade de elementos alcançado.");
                }
            }
            else
            {
                for (int i = 0; i < elementos.Count; i++)
                {
                    if (elementos[i].getNumero().Equals(elementoB))
                    {
                        vB = elementos[i];
                    }
                }
            }

            Elemento vA = null;
            if (!existeA)
            {
                vA = new Elemento(elementoA);
                vA.addConexao(vB);
                vB.addConexao(vA);
                qtdAtualElementos++;
                if (qtdAtualElementos > qtdTotalElementos)
                {
                    throw new System.Exception("Limite de quantidade de elementos alcançado.");
                }
            }
            else
            {
                for (int i = 0; i < elementos.Count; i++)
                {
                    if (elementos[i].getNumero().Equals(elementoA))
                    {
                        elementos[i].addConexao(vB);
                        break;
                    }
                }
            }

            if (!existeA)
            {
                elementos.Add(vA);
            }
            if (!existeB)
            {
                elementos.Add(vB);
            }
        }

        public Boolean Consulta(int elementoA, int elementoB)
        {
            elementos[0].setCor(VISITADO);
            // Q é a lista que contém os vértices que serão verificados. São os vértices que são "Alcançados" pelo elementoA
            Q = new List<Elemento>();
            AdicionaElemento(Q, elementos[0]);
            for (int v = 0; v < elementos.Count; v++)
            {
                if (elementos[v].getNumero().Equals(elementoA))
                {
                    while (Q.Count != 0)
                    {
                        // Pega e remove o primeiro elemento de Q
                        Elemento u = RemoveElementoDeQ();
                        // pega as conexões existentes em Q
                        List<Elemento> conexoesLista = u.getConexoes();
                        for (int a = 0; a < conexoesLista.Count; a++)
                        {
                            if (conexoesLista[a].getNumero().Equals(elementoB))
                            {
                                // Se houver uma conexão direta ou indireta retorna true
                                return true;
                            }
                            // Verifica se o o elemento já foi verificado
                            if (NAO_VISITADO.Equals(conexoesLista[a].getCor()))
                            {
                                AdicionaElemento(Q, conexoesLista[a]);
                                conexoesLista[a].setCor(VISITADO);
                            }
                        }
                        u.setCor(VISITADO_NOS);
                    }
                    break;
                }
            }
            return false;
        }

        private void AdicionaElemento(List<Elemento> Q, Elemento elemento)
        {
            if (!Q.Contains(elemento))
            {
                Q.Add(elemento);
            }
        }

        private Elemento RemoveElementoDeQ()
        {
            Elemento primeiro = Q[0];
            Q.Remove(primeiro);
            return primeiro;
        }
    }
}