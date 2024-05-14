import {siren, sequence, direction, notePosition } from "./siren/index.js"
import * as assert from "assert"

describe('sequence diagram', function(){
  it('simple', function(){
      const actual = siren.sequence([
            sequence.messageArrow( "Alice",  "John", "Hello John, how are you?"),
            sequence.messageDottedArrow( "John",  "Alice", "Great!"),
            sequence.messageOpenArrow( "Alice",  "John", "See you later!")
        ]).write();
      const expected = `sequenceDiagram
    Alice->>John: Hello John, how are you?
    John-->>Alice: Great!
    Alice-)John: See you later!
`
      assert.equal(actual,expected,"This should be equal")
  });
  it('create/destroy', function(){
    const [alice, bob, carl, donald] =  ["Alice", "Bob", "Carl", "D"]
    const actual = siren.sequence([
          sequence.messageArrow(alice, bob, "Hello Bob, how are you?"),
          sequence.messageArrow(bob, alice, "Fine, thank you. And you?"),
          sequence.createParticipant (carl),
          sequence.messageArrow(alice, carl, "Hi Carl!"),
          sequence.createActor(donald, "Donald"),
          sequence.messageArrow(carl, donald, "Hi!"),
          sequence.destroy (carl),
          sequence.messageCross(alice, carl, "We are too many"),
          sequence.destroy (bob),
          sequence.messageArrow(bob, alice, "I agree")
      ]).write();
    const expected = `sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    Bob->>Alice: Fine, thank you. And you?
    create participant Carl
    Alice->>Carl: Hi Carl!
    create actor D as Donald
    Carl->>D: Hi!
    destroy Carl
    Alice-xCarl: We are too many
    destroy Bob
    Bob->>Alice: I agree
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('nested activation', function(){
    const [alice, john] =  ["Alice", "John"]
    const actual = siren.sequence([
          sequence.messageArrow(alice, john, "Hello John, how are you?", true),
          sequence.messageArrow(alice, john, "John, can you hear me?", true),
          sequence.messageDottedArrow(john, alice, "Hi Alice, I can hear you!", false),
          sequence.messageDottedArrow(john, alice, "I feel great!", false)
      ]).write();
    const expected = `sequenceDiagram
    Alice->>+John: Hello John, how are you?
    Alice->>+John: John, can you hear me?
    John-->>-Alice: Hi Alice, I can hear you!
    John-->>-Alice: I feel great!
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('note', function(){
    const [alice, john] =  ["Alice", "John"]
    const actual = siren.sequence([
          sequence.message(alice, john, "Hello John, how are you?"),
          sequence.noteSpanning(alice, john, "A typical interaction<br/>But now in two lines", notePosition.over)
      ]).write();
    const expected = `sequenceDiagram
    Alice->John: Hello John, how are you?
    note over Alice,John : A typical interaction<br/>But now in two lines
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('alt-else-opt', function(){
    const actual = siren.sequence([
          sequence.messageArrow("Alice", "Bob", "Hello Bob, how are you?"),
          sequence.alt (
              "is sick", 
              [sequence.messageArrow("Bob", "Alice", "Not so good :(")], 
              [
                  // One else condition
                  ["is well", [
                      sequence.messageArrow("Bob", "Alice", "Feeling fresh like a daisy")
                  ]]
              ]
          ),
          sequence.opt ("Extra response", [
              sequence.messageArrow("Bob", "Alice", "Thanks for asking")
          ])
      ]).write();
    const expected = `sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    alt is sick
        Bob->>Alice: Not so good :(
    else is well
        Bob->>Alice: Feeling fresh like a daisy
    end
    opt Extra response
        Bob->>Alice: Thanks for asking
    end
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('parallel', function(){
    const actual = siren.sequence([
          sequence.par ("Alice to Bob", [
                  sequence.messageArrow("Alice", "Bob", "Hello guys!")
          ], [
              ["Alice to John", [
                  sequence.messageArrow("Alice", "John", "Hello guys!")
              ]],
              ["Alice to Fred", [
                  sequence.messageArrow("Alice", "Fred", "Hello guys!")
              ]]
          ]),
          sequence.messageDottedArrow("Bob", "Alice", "Hi Alice!"),
          sequence.messageDottedArrow("John", "Alice", "Hi Alice!"),
          sequence.messageDottedArrow("Fred", "Alice", "Hi Alice!")
      ]).write();
    const expected = `sequenceDiagram
    par Alice to Bob
        Alice->>Bob: Hello guys!
    and Alice to John
        Alice->>John: Hello guys!
    and Alice to Fred
        Alice->>Fred: Hello guys!
    end
    Bob-->>Alice: Hi Alice!
    John-->>Alice: Hi Alice!
    Fred-->>Alice: Hi Alice!
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('autonumber-loop', function(){
    const [alice, john, bob] = ["Alice", "John", "Bob"]
    const actual = siren.sequence([
          sequence.autoNumber,
          sequence.messageArrow(alice, john, "Hello John, how are you?"),
          sequence.loop("HealthCheck", [
              sequence.messageArrow(john, john, "Fight against hypochondria")
          ]),
          sequence.note(john, "Rational thoughts!", notePosition.rightOf),
          sequence.messageDottedArrow(john, alice, "Great!"),
          sequence.messageArrow(john, bob, "How about you?"),
          sequence.messageDottedArrow(bob, john, "Jolly good!")
      ]).write();
    const expected = `sequenceDiagram
    autonumber
    Alice->>John: Hello John, how are you?
    loop HealthCheck
        John->>John: Fight against hypochondria
    end
    note right of John : Rational thoughts!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('actor-links', function(){
    const [alice, john] = ["Alice", "John"]
    const actual = siren.sequence([
          sequence.participant(alice),
          sequence.participant(john),
          sequence.link(alice, "Dashboard", "https://dashboard.contoso.com/alice"),
          sequence.link(alice, "Wiki", "https://wiki.contoso.com/alice"),
          sequence.link(john, "Dashboard", "https://dashboard.contoso.com/john"),
          sequence.link(john, "Wiki", "https://wiki.contoso.com/john"),
          sequence.messageArrow(alice, john, "Hello John, how are you?")
      ]).write();
    const expected = `sequenceDiagram
    participant Alice
    participant John
    link Alice: Dashboard @ https://dashboard.contoso.com/alice
    link Alice: Wiki @ https://wiki.contoso.com/alice
    link John: Dashboard @ https://dashboard.contoso.com/john
    link John: Wiki @ https://wiki.contoso.com/john
    Alice->>John: Hello John, how are you?
`
    assert.equal(actual,expected,"This should be equal")
  });

});