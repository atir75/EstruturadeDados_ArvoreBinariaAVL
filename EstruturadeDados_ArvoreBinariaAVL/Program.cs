using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EstruturadeDados_ArvoreBinariaAVL
{
    class Arvore
    {
        public Arvore()
        {
            info = 0;
            sae = sad = null;
        }

        static int FB()
        {
            Arvore sae, sad = null;
            int FB;
            FB = sad - sae;
            return FB;
        }

        public void Insere(int n, ref Arvore RAIZ)
        {
            Arvore temp, subarv;
            this.info = n;

            if (RAIZ == null)
                RAIZ = this;
            else
            {
                temp = RAIZ;
                while (temp != null)
                {
                    subarv = temp;
                    if (n <= temp.info)
                    {
                        temp = temp.sae;
                        if (temp == null) subarv.sae = this;
                    }
                    else
                    {
                        temp = temp.sad;
                        if (temp == null) subarv.sad = this;
                    }
                }
            }

            
        }

        public int Pesquisa(int n)
        {
            Arvore temp = this;
            int nivel, achou;
            nivel = achou = 0;

            while (temp != null && achou == 0)
            {
                if (n == temp.info)
                    achou = 1;
                else
                {
                    if (n <= temp.info)
                        temp = temp.sae;
                    else
                        temp = temp.sad;
                }
            }

            if (achou == 1)
                return (nivel);
            else return (-1);
        }

        public void MostraArvorePreOrdem()
        {
            Console.Write("{0} ", this.info);
            if (this.sae != null) (this.sae).MostraArvorePreOrdem();
            if (this.sad != null) (this.sad).MostraArvorePreOrdem();
        }

        public void MostraArvoreOrdemSimetrica()
        {
            if (this.sae != null) (this.sae).MostraArvoreOrdemSimetrica();
            Console.Write("{0} ", this.info);
            if (this.sad != null) (this.sad).MostraArvoreOrdemSimetrica();
        }

        public void MostraArvorePosOrdem()
        {
            if (this.sae != null) (this.sae).MostraArvorePosOrdem();
            if (this.sad != null) (this.sad).MostraArvorePosOrdem();
            Console.Write("{0} ", this.info);
        }

        public void MostraArvoreEmOrdem()
        {
            List<Arvore> ArrayArvore = new List<Arvore>() { this };
            Arvore temp;

            while (ArrayArvore.Count != 0)
            {
                temp = ArrayArvore.First();
                Console.Write("{0} ", temp.info);
                if (temp.sae != null) ArrayArvore.Add(temp.sae);
                if (temp.sad != null) ArrayArvore.Add(temp.sad);
                ArrayArvore.RemoveAt(0);
            }
        }

        public void MaiorNivel(ref int maiornivel, ref int nivelsa)
        {
            if (nivelsa > maiornivel) maiornivel = nivelsa;
            nivelsa++;
            if (this.sae != null) (this.sae).MaiorNivel(ref maiornivel, ref nivelsa);
            if (this.sad != null) (this.sad).MaiorNivel(ref maiornivel, ref nivelsa);
            nivelsa--;
        }
        
        ~Arvore()
        {
            Console.Write("Arvore Binaria excluida");
            Console.ReadKey();
        }
        private int info;
        Arvore sae;
        Arvore sad;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Arvore RAIZ = null;
            Arvore arv;

            int n, i, escolha;
            do
            {
                Console.Clear();
                Console.WriteLine(" Menu Principal");
                Console.WriteLine("(1) - Insere um elemento na Árvore");
                Console.WriteLine("(2) - Pesquisa um elemento na Árvore");
                Console.WriteLine("(3) - Lista Arvore - Pré-Ordem");
                Console.WriteLine("(4) - Lista Arvore - Ordem Simétrica");
                Console.WriteLine("(5) - Lista Arvore - Pos-Ordem");
                Console.WriteLine("(6) - Lista Arvore - Em Ordem");
                Console.WriteLine("(7) - Calcula Maior Nivel");
                Console.WriteLine("(8) - Para SAIR");
                escolha = int.Parse(Console.ReadKey(true).KeyChar.ToString
               ());

                switch (escolha)
                {
                    case 1: // Insere um elemento na Arvore
                        Console.Clear();
                        arv = new Arvore();
                        Console.Write("Entre com um numero : ");
                        n = int.Parse(Console.ReadLine());
                        arv.Insere(n, ref RAIZ);
                        break;
                }
            } while (escolha != 8);
        }
    }
    
 
}
