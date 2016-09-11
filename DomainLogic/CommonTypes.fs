namespace DomainLogic

module CommonTypes = 
    open System
    
    type Name = 
        | Name of string
    
    type InternalId = 
        | InternalId of Guid
    
    type ExternalId = 
        | ExternalId of string

    type Result<'TSuccess,'TError> = 
     | Success of 'TSuccess 
     | Error of 'TError


module PositiveNumber = 
    type PositiveNumber = PositiveNumber of int
        with
            static member (*) (PositiveNumber x, PositiveNumber y) =
                x * y |> PositiveNumber
            static member (/) (PositiveNumber x, PositiveNumber y) =
                x / y |> PositiveNumber

    let private error (number: int) =
        sprintf "Number value is %d must be non negative" number
        
    let createWithContinuation success failure (number: int) = 
        match number with
        | good when good > 0 -> PositiveNumber good |> success
        | _ -> number |> error |> failure

    let create number = 
        let success artefact = Some artefact
        let failure _  = None
        createWithContinuation success failure number

    let apply f (PositiveNumber e) = f e

    let value e = apply id e

module NotNegativeNumber = 
    open PositiveNumber

    type NotNegativeNumber = NotNegativeNumber of int
        with
            static member Increment(NotNegativeNumber x) = 
                x + 1 |> PositiveNumber

    let private error (number: int) =
        sprintf "Number value is %d must be non negative" number
        
    let createWithContinuation success failure (number: int) = 
        match number with
        | good when good >= 0 -> NotNegativeNumber good |> success
        | _ -> number |> error |> failure

    let create number = 
        let success artefact = Some artefact
        let failure _  = None
        createWithContinuation success failure number

    let apply f (NotNegativeNumber e) = f e

    let value e = apply id e