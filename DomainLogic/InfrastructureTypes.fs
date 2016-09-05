namespace DomainLogic

module InfrastructureTypes =
    open System

    type NotNegativeNumber = NotNegativeNumber of int
    type Name = Name of string
    type InternalId = InternalId of Guid
    type ExternalId = ExternalId of string