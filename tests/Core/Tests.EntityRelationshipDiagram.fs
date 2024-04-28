module Tests.EntityRelationshipDiagram

open Fable.Pyxpecto
open Siren

let private tests_entity = testList "entity" [
    testCase "simple" <| fun _ ->
        let actual =
            siren.erDiagram [
                erDiagram.entity ("CUSTOMER")
                erDiagram.entity ("ORDER", "CUSTOMER ORDER")
            ]
            |> siren.write
        let expected = """erDiagram
    CUSTOMER
    ORDER["CUSTOMER ORDER"]
"""
        Expect.trimEqual actual expected ""
    testCase "attributes" <| fun _ ->
        let actual =
            siren.erDiagram [
                erDiagram.entity ("ORDER", "CUSTOMER ORDER", attr=[
                    erDiagram.attribute("string", "name")
                    erDiagram.attribute("string", "driverLicence", [erKey.fk; erKey.pk], "Just some example")
                    erDiagram.attribute("string", "carRegistrationNumber", comment="no keys")
                ])
            ]
            |> siren.write
        let expected = """erDiagram
    ORDER["CUSTOMER ORDER"] {
        string name
        string driverLicence FK, PK "Just some example"
        string carRegistrationNumber "no keys"
    }
"""
        Expect.trimEqual actual expected ""
        
]

let private tests_relationship = testList "relationship" [
    let mkId (o: obj) = sprintf "CUSTOMER%A" o
    testCase "two-way" <| fun _ ->
        let actual =
            siren.erDiagram [
                erDiagram.relationship (mkId 1, erCardinality.onlyOne, mkId 5, erCardinality.onlyOne, "onlyOne")
                erDiagram.relationship (mkId 2, erCardinality.oneOrMany, mkId 6, erCardinality.oneOrMany, "oneOrMany")
                erDiagram.relationship (mkId 3, erCardinality.oneOrZero, mkId 7, erCardinality.oneOrZero, "oneOrZero")
                erDiagram.relationship (mkId 4, erCardinality.zeroOrMany, mkId 8, erCardinality.zeroOrMany, "zeroOrMany")
            ]
            |> siren.write
        let expected = """erDiagram
    CUSTOMER1 only one to only one CUSTOMER5 : onlyOne
    CUSTOMER2 one or many to one or many CUSTOMER6 : oneOrMany
    CUSTOMER3 one or zero to one or zero CUSTOMER7 : oneOrZero
    CUSTOMER4 zero or many to zero or many CUSTOMER8 : zeroOrMany
"""
        Expect.trimEqual actual expected ""
    testCase "optional" <| fun _ ->
        let actual =
            siren.erDiagram [
                erDiagram.relationship (mkId 1, erCardinality.onlyOne, mkId 5, erCardinality.onlyOne, "onlyOne", true)
                erDiagram.relationship (mkId 2, erCardinality.oneOrMany, mkId 6, erCardinality.oneOrMany, "oneOrMany", true)
                erDiagram.relationship (mkId 3, erCardinality.oneOrZero, mkId 7, erCardinality.oneOrZero, "oneOrZero", true)
                erDiagram.relationship (mkId 4, erCardinality.zeroOrMany, mkId 8, erCardinality.zeroOrMany, "zeroOrMany", true)
            ]
            |> siren.write
        let expected = """erDiagram
    CUSTOMER1 only one optionally to only one CUSTOMER5 : onlyOne
    CUSTOMER2 one or many optionally to one or many CUSTOMER6 : oneOrMany
    CUSTOMER3 one or zero optionally to one or zero CUSTOMER7 : oneOrZero
    CUSTOMER4 zero or many optionally to zero or many CUSTOMER8 : zeroOrMany
"""
        Expect.trimEqual actual expected ""
]

let private tests_complex = testList "complex" [
    testCase "Manufacturer" <| fun _ ->
        let CAR, NAMED_DRIVER, PERSON, MANUFACTURER = "CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER"
        let actual =
            siren.erDiagram [
                erDiagram.relationship (CAR, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "allows")
                erDiagram.entity (CAR,attr=[
                    erDiagram.attribute("string", "registrationNumber", [erKey.pk])
                    erDiagram.attribute("string", "make")
                    erDiagram.attribute("string", "model")
                    erDiagram.attribute("string[]", "parts")
                ])
                erDiagram.relationship (PERSON, erCardinality.onlyOne, NAMED_DRIVER, erCardinality.zeroOrMany, "is")
                erDiagram.entity (PERSON,attr=[
                    erDiagram.attribute("string", "driversLicense", [erKey.pk], "The license is #")
                    erDiagram.attribute("string(99)", "firstName", comment="Only 99 characters are allowed")
                    erDiagram.attribute("string", "lastName")
                    erDiagram.attribute("string", "phone", [erKey.uk])
                    erDiagram.attribute("int", "age")
                ])
                erDiagram.entity(NAMED_DRIVER, attr=[
                    erDiagram.attribute("string", "carRegistrationNumber", [erKey.pk; erKey.fk])
                    erDiagram.attribute("string", "driverLicence", [erKey.pk; erKey.fk])
                ])
                erDiagram.relationship(MANUFACTURER,erCardinality.onlyOne,CAR,erCardinality.zeroOrMany,"makes")
            ]
            |> siren.write
        let expected = """erDiagram
    CAR only one to zero or many NAMED-DRIVER : allows
    CAR {
        string registrationNumber PK
        string make
        string model
        string[] parts
    }
    PERSON only one to zero or many NAMED-DRIVER : is
    PERSON {
        string driversLicense PK "The license is #"
        string(99) firstName "Only 99 characters are allowed"
        string lastName
        string phone UK
        int age
    }
    NAMED-DRIVER {
        string carRegistrationNumber PK, FK
        string driverLicence PK, FK
    }
    MANUFACTURER only one to zero or many CAR : makes
"""
        Expect.trimEqual actual expected ""
]

let main = testList "EntityRelationshipDiagram" [
    tests_entity
    tests_relationship
    tests_complex
]

