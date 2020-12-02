// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
namespace Lab3


module Lab3fs =
    open Lab3
    open System

    // type Register = { Bits: sbyte array; Name: string }

    // let count register = register.Bits.Length

    // type Register(n, name) =
    //         let mutable registers: List<Register> = []
    //         member this.Name = name

    //         member private this.Bits:sbyte array = [|sbyte 0; sbyte 0;sbyte 0|]
    //         member  this.Count = this.Bits.Length;



    //         member this.Bytes = this.ToString()
    //         member this.Item with get (index) = this.Bits.[index]
    //                            and set index value = this.Bits.[index] <- value



    //         static member private Registers with get() = registers
    //                                         and set(value) = registers <- value
    //         // List<Register>

    //         public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

    //         public override string ToString()
    //         {
    //             var result = new StringBuilder();

    //             foreach (var @sbyte in Bits)
    //             {
    //                 int n = Convert.ToString(@sbyte, 2).Count();
    //                 var bitString = "00000000" + Convert.ToString(@sbyte, 2);
    //                 bitString = bitString.Substring(n);
    //                 result.Append(bitString);
    //             }

    //             return result.ToString();
    //         }



    //         public static Register GetRegister(string name)
    //         {
    //             try
    //             {
    //                 return Registers.Single(r => r.Name == name);
    //             }
    //             catch { return null; }
    //         }


    //         public Register(int n, string name)
    //         {
    //             Name = name;
    //             Bits = To24BitsArray(n);
    //             if (Registers.FindIndex(c => c.Name == name) == -1)
    //                 Registers.Add(this);
    //             Bytes = ToString();
    //         }


    //         private static sbyte[] To24BitsArray(int n)
    //         {
    //             //Cutting all extra bits.
    //             n %= (int)Math.Pow(2, 23);

    //             //Converting number...
    //             sbyte[] intBytes = BitConverter.GetBytes(n).Select(b => (sbyte)b).ToArray();

    //             //Reverse if it is necessary.
    //             if (BitConverter.IsLittleEndian)
    //                 Array.Reverse(intBytes);

    //             //Skip first zero byte.
    //             return intBytes.Skip(1).ToArray();
    //         }


    //     }


    let printState (processor: ProcessorViewModel) =
        sprintf "IR : %s\nR1: %s\nR2: %s\nR3: %s\nR4: %s\nPS: %s\nPC: %i\nTC: %i\n" processor.IR
            (processor.R1.ToString()) (processor.R2.ToString()) (processor.R3.ToString()) (processor.R4.ToString())
            (if processor.PS then "+" else "-") (processor.PC) (processor.TC)

    let from whom = sprintf "from %s" whom

    [<EntryPoint>]
    let main argv =
        let processorViewModel = ProcessorViewModel()
        while processorViewModel.canExecute () do
            Console.ReadKey()
            processorViewModel.executeTact ()
            processorViewModel |> printState |> printfn "%s"
        0 // return an integer exit code
