namespace RoboTupiniquim
{
    internal class Program
    {
        static void releituraInicio(ref int xI, ref int yI, int xMaximo, int yMaximo)
        {
            while (xI > xMaximo || yI > yMaximo)
            {
                Console.WriteLine();
                Console.WriteLine("Valor de Inicio maior que o tamanho da area, digite um valor valido para x e y");
                Console.WriteLine("Coordenada X: ");
                xI = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Coordenada Y: ");
                yI = Convert.ToInt32(Console.ReadLine());
            }
        }

        static string lerMovimentacao()
        {
            string movimentacao;

            Console.WriteLine();
            Console.Write("Digite a movimentação do robô (E - esquerda; D - Direita; M - mover): ");
            movimentacao = Console.ReadLine();
            return movimentacao;
        }

        static void moverRobo(ref int contX, ref int contY, string op, char faceI)
        {
            if (op != null)
            {
                switch (op)
                {
                    case "+x":
                        contX = contX + 1;
                        break;

                    case "-x":
                        contX = contX - 1;
                        break;

                    case "+y":
                        contY = contY + 1;
                        break;

                    case "-y":
                        contY = contY - 1;
                        break;
                }
            }
            else
            {
                switch (faceI)
                {
                    case 'n':
                        contY = contY + 1;
                        break;

                    case 's':
                        contY = contY - 1;
                        break;

                    case 'l':
                        contX = contX + 1;
                        break;

                    case 'o':
                        contX = contX - 1;
                        break;
                }
            }
        }

        static string virarDireita(string op, ref char faceI)
        {
            switch (faceI)
            {
                case 'n':
                    op = "+x";
                    faceI = 'l';
                    break;

                case 's':
                    op = "-x";
                    faceI = 'o';
                    break;

                case 'l':
                    op = "-y";
                    faceI = 's';
                    break;

                case 'o':
                    op = "+y";
                    faceI = 'n';
                    break;
            }

            return op;
        }

        static string virarEsquerda(string op, ref char faceI)
        {
            string op = null;

            switch (faceI)
            {
                case 'n':
                    op = "-x";
                    faceI = 'o';
                    break;

                case 's':
                    op = "+x";
                    faceI = 'l';
                    break;

                case 'l':
                    op = "+y";
                    faceI = 'n';
                    break;

                case 'o':
                    op = "-y";
                    faceI = 's';
                    break;
            }

            return op;
        }

        static void Main(string[] args)
        {
            string coord;
            int xI, yI;
            char faceI;
            string xyMaximo;
            int yMaximo, xMaximo;

            //==========================================================
            Console.Write("Digite o valor do X e Y Maximo da area: ");
            xyMaximo = Console.ReadLine();
            string[] xyMvet = xyMaximo.Split();
            xMaximo = Convert.ToInt32(xyMvet[0]);
            yMaximo = Convert.ToInt32(xyMvet[1]);

            //==========================================================
            Console.WriteLine();
            Console.Write("Digite as coordenada Iniciais (x, y) respectivamente " +
                "\nE para onde o robo esta virado: ");
            coord = Console.ReadLine();

            string[] coordenadaI = coord.Split(" ");
            xI = Convert.ToInt32(coordenadaI[0]);
            yI = Convert.ToInt32(coordenadaI[1]);
            faceI = Convert.ToChar(coordenadaI[2]);

            int contX = xI;
            int contY = yI;

            //==========================================================

            char[] moVetor = lerMovimentacao().ToCharArray();

            //==========================================================

            if(xI > xMaximo || yI > yMaximo)
            {
                releituraInicio(ref xI, ref yI, xMaximo, yMaximo);
            }

            //==========================================================
            string op = null;
            for (int i = 0; i < moVetor.Length; i++)
            {
                switch (moVetor[i])
                {
                    case 'e':
                        virarEsquerda(op, ref faceI);
                        break;

                    case 'd':
                        virarDireita(op, ref faceI);
                        break;

                    case 'm':
                        moverRobo(ref contX, ref contY, op, faceI)
                        break;

                }
            }

	        Console.WriteLine();
            Console.WriteLine("Localização final do robo");
            Console.WriteLine(contX+", "+contY+", "+faceI);
        }
    }
}