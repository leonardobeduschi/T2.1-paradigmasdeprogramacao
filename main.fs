// trabalho 2.1 - paradigmas de programação
// professor: rodrigo lyra
// aluno: leonardo beduschi iunes

open System

// EXERCÍCIO 1
printfn "Exercício 1"
let DivideMaiorMenor(x1: float, x2: float) : Option<float> =
// verifica qual o maior e o menor valor
    let maior, menor =
        if x1 > x2 then
            x1, x2
        else
            x2, x1

// divide o maior pelo menor (se o menor for 0 não é permitido)
    if menor = 0.0 then
        printfn "Não é permitido dividir por 0"
        None // retorna "none" pois deu erro
    else
        Some (maior / menor) // retorna "some"

// teste resultados 1
let resultado1 = DivideMaiorMenor(8.0, 4.0)
match resultado1 with
| Some valor -> printfn "Resultado: %f" valor
| None -> printfn "Erro"

let resultado2 = DivideMaiorMenor(5.0, 0.0)
match resultado2 with
| Some valor -> printfn "Resultado: %f" valor
| None -> printfn "Erro"
printfn ""



// EXERCÍCIO 2
printfn "Exercício 2"
let Triangulo(x1: float) (x2: float) (x3: float) =
    if x1 > (x2+x3) || x2 > (x1+x3) || x3 > (x1+x2) then
        printfn "Não forma um triângulo"
    elif x1 = x2 && x2 = x3 then
        printfn "Equilátero"
    elif x1 = x2 || x1 = x3 || x2 = x3 then
        printfn "Isósceles"
    else
        printfn "Escaleno"

// teste resultados 2
Triangulo 5.0 5.0 5.0  // equilátero
Triangulo 2.0 3.0 3.0  // isósceles
Triangulo 4.0 5.0 6.0  // escaleno
Triangulo 2.0 2.0 5.0  // não forma um triângulo
printfn ""



// EXERCÍCIO 3
printfn "Exercício 3"
let Vetor() : int[] =
    [0..20] |> Array.ofList

let Pares (vetor: int[]) : int[] =
    vetor |> Array.filter (fun x -> x % 2 = 0)

let Multiplicar (vetor: int[]) : int[] =
    vetor |> Array.map (fun x -> x * 2)

let MultiplosDe6 (vetor: int[]) : int[] =
    vetor |> Array.filter (fun x -> x % 6 = 0)

// funções em cadeia
let vetor = Vetor()
let pares = vetor |> Pares
let multiplicarPares = pares |> Multiplicar
let multiplos6 = multiplicarPares |> MultiplosDe6

// resultados
printfn "Vetor original: %A" vetor
printfn "Números pares: %A" pares
printfn "Pares multiplicados por 2: %A" multiplicarPares
printfn "Múltiplos de 6: %A" multiplos6

printfn ""


// EXERCÍCIO 4
printfn "Exercício 4"
// lê um número do usuário
let LerNumero mensagem =
    printf "%s" mensagem
    let entrada = Console.ReadLine() // ler a entrada do usuário
    match Int32.TryParse(entrada) with // tenta converter valor para inteiro
    | (true, numero) -> float numero
    | (false, _) -> 
        printfn "Inválido."
        0.0

// lê três números do usuário
let LerTresNumeros () =
    let n1 = LerNumero "Digite o primeiro número: "
    let n2 = LerNumero "Digite o segundo número: "
    let n3 = LerNumero "Digite o terceiro número: "
    (n1, n2, n3)

// calcula a média
let CalcularMedia (n1: float) (n2: float) (n3: float) : float =
    (n1 + n2 + n3) / 3.0

// verifica se a média é maior, menor ou igual a 6
let MaiorOuMenor6 media =
    if media > 6.0 then
        printfn "A média é maior que 6"
    elif media < 6.0 then
        printfn "A média é menor que 6"
    else
        printfn "A média é 6"

// exibe se foi aprovado ou reprovado
let MensagemResultado aprovado =
    if aprovado then
        printfn "Você foi aprovado."
    else
        printfn "Você foi reprovado."

// função que chama as outras funções e gera os resultados
let Resultado () =
    let (num1, num2, num3) =
        LerTresNumeros()
        
    let media =
        CalcularMedia num1 num2 num3

    // exibe os números digitados e a média
    printfn "Você digitou: %f, %f, %f" num1 num2 num3
    printfn "A média dos valores é: %f" media

    // verifica se a média é maior, menor ou igual a 6
    MaiorOuMenor6 media

    // verificar se foi aprovado ou reprovado e exibir mensagem
    let aprovado = media >= 6.0
    MensagemResultado aprovado

// chama a função Resultado
Resultado ()

[<EntryPoint>]
let main argv =
    0 // return an integer exit code
