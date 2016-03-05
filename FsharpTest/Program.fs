// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let anInt = 5
let aString = "Hello"
// Perform a simple calculation and bind anIntSquared to the result.
let anIntSquared = anInt * anInt

System.Console.WriteLine(anInt)
System.Console.WriteLine(aString)
System.Console.WriteLine(anIntSquared)

let square n = n * n
// Call the function to calculate the square of anInt, which has the value 5.
let result = square anInt
// Display the result.
System.Console.WriteLine(result)

let rec factorial n = 
    if n = 0 
    then 1 
    else n * factorial (n - 1)
System.Console.WriteLine(factorial anInt)

let turnChoices = ("right", "left")
System.Console.WriteLine(turnChoices)
// Output: (right, left)

let intAndSquare = (anInt, square anInt)
System.Console.WriteLine(intAndSquare)
// Output: (5,25)

// List of best friends.
let bffs = [ "Susan"; "Kerry"; "Linda"; "Maria" ] 

// Bind newBffs to a new list that has "Katie" as its first element.
let newBffs = "Katie" :: bffs

printfn "%A" bffs
// Output: ["Susan"; "Kerry"; "Linda"; "Maria"]
printfn "%A" newBffs
// Output: ["Katie"; "Susan"; "Kerry"; "Linda"; "Maria"]

// The declaration creates a constructor that takes two values, name and age.
type Person(name:string, age:int) =
    // A Person object's age can be changed. The mutable keyword in the
    // declaration makes that possible.
    let mutable internalAge = age

    // Declare a second constructor that takes only one argument, a name.
    // This constructor calls the constructor that requires two arguments,
    // sending 0 as the value for age.
    new(name:string) = Person(name, 0)

    // A read-only property.
    member this.Name = name
    // A read/write property.
    member this.Age
        with get() = internalAge
        and set(value) = internalAge <- value

    // Instance methods.
    // Increment the person's age.
    member this.HasABirthday () = internalAge <- internalAge + 1

    // Check current age against some threshold.
    member this.IsOfAge targetAge = internalAge >= targetAge

    // Display the person's name and age.
    override this.ToString () = 
        "Name:  " + name + "\n" + "Age:   " + (string)internalAge


// The following let expressions are not part of the Person class. Make sure
// they begin at the left margin.
let person1 = Person("John", 43)
let person2 = Person("Mary")

// Send a new value for Mary's mutable property, Age.
person2.Age <- 15
// Add a year to John's age.
person1.HasABirthday()

// Display results.
System.Console.WriteLine(person1.ToString())
System.Console.WriteLine(person2.ToString())
// Is Mary old enough to vote?
System.Console.WriteLine(person2.IsOfAge(18))

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code