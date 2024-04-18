module Build.Examples.EntityRelationshipDiagram

open Util
open Siren

let writeCarExample() =
    let key = "Example3"
    let codeDisplay = """let CAR, NAMED_DRIVER, PERSON, MANUFACTURER = "CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER"
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
"""
    let CAR, NAMED_DRIVER, PERSON, MANUFACTURER = "CAR", "NAMED-DRIVER", "PERSON", "MANUFACTURER"
    let mermaidMd = 
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
    let replacement = $"""
```fsharp
{codeDisplay}
```

```mermaid
{mermaidMd}
```
"""
    writeExample(key, replacement)