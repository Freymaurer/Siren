from siren.index import siren, sequence, note_position

class TestSequenceDiagram:

  def test_simple(self):
      actual = siren.sequence([
            sequence.message_arrow( "Alice",  "John", "Hello John, how are you?"),
            sequence.message_dotted_arrow( "John",  "Alice", "Great!"),
            sequence.message_open_arrow( "Alice",  "John", "See you later!")
        ]).write()
      expected = """sequenceDiagram
    Alice->>John: Hello John, how are you?
    John-->>Alice: Great!
    Alice-)John: See you later!
"""
      assert actual == expected
  def test_create_destroy(self):
      alice, bob, carl, donald = "Alice", "Bob", "Carl", "D"
      actual = siren.sequence ([
            sequence.message_arrow(alice, bob, "Hello Bob, how are you?"),
            sequence.message_arrow(bob, alice, "Fine, thank you. And you?"),
            sequence.create_participant(carl),
            sequence.message_arrow(alice, carl, "Hi Carl!"),
            sequence.create_actor(donald, "Donald"),
            sequence.message_arrow(carl, donald, "Hi!"),
            sequence.destroy(carl),
            sequence.message_cross(alice, carl, "We are too many"),
            sequence.destroy(bob),
            sequence.message_arrow(bob, alice, "I agree"),
        ]).write()
      expected = """sequenceDiagram
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
"""
      assert actual == expected
  def test_nested_activation(self):
      alice, john = "Alice", "John"
      actual = siren.sequence([
            sequence.message_arrow(alice, john, "Hello John, how are you?", True),
            sequence.message_arrow(alice, john, "John, can you hear me?", True),
            sequence.message_dotted_arrow(john, alice, "Hi Alice, I can hear you!", False),
            sequence.message_dotted_arrow(john, alice, "I feel great!", False)
        ]).write()
      expected = """sequenceDiagram
    Alice->>+John: Hello John, how are you?
    Alice->>+John: John, can you hear me?
    John-->>-Alice: Hi Alice, I can hear you!
    John-->>-Alice: I feel great!
"""
      assert actual == expected
  def test_note(self):
      alice, john = "Alice", "John"
      actual = siren.sequence([
              sequence.message(alice, john, "Hello John, how are you?"),
              sequence.note_spanning(alice, john, "A typical interaction<br/>But now in two lines", note_position.over())
          ]).write()
      expected = """sequenceDiagram
    Alice->John: Hello John, how are you?
    note over Alice,John : A typical interaction<br/>But now in two lines
"""
      assert actual == expected
  def test_alt_else_opt(self):
      alice, bob = "Alice", "Bob"
      actual = siren.sequence([
                sequence.message_arrow(alice, bob, "Hello Bob, how are you?"),
                sequence.alt("is sick", [
                    sequence.message_arrow(bob, alice, "Not so good :(")
                ], 
                [
                    # One else condition
                    ("is well", [
                        sequence.message_arrow(bob, alice, "Feeling fresh like a daisy")
                    ])
                ]),
                sequence.opt ("Extra response", [
                    sequence.message_arrow(bob, alice, "Thanks for asking")
                ])
            ]).write()
      expected = """sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    alt is sick
        Bob->>Alice: Not so good :(
    else is well
        Bob->>Alice: Feeling fresh like a daisy
    end
    opt Extra response
        Bob->>Alice: Thanks for asking
    end
"""
      assert actual == expected
  def test_parallel(self):
      alice, john, bob, fred = "Alice", "John", "Bob", "Fred"
      actual = siren.sequence([
          sequence.par("Alice to Bob", [
                  sequence.message_arrow(alice, bob, "Hello guys!")
          ], [
              ("Alice to John", [
                  sequence.message_arrow(alice, john, "Hello guys!")
              ]),
              ("Alice to Fred", [
                  sequence.message_arrow(alice, fred, "Hello guys!")
              ])
          ]),
          sequence.message_dotted_arrow(bob, alice, "Hi Alice!"),
          sequence.message_dotted_arrow(john, alice, "Hi Alice!"),
          sequence.message_dotted_arrow(fred, alice, "Hi Alice!")
      ]).write()
      expected = """sequenceDiagram
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
"""
      assert actual == expected
  def test_autonumber_loop(self):
      alice, john, bob = "Alice", "John", "Bob"
      actual = siren.sequence([
          sequence.auto_number(),
          sequence.message_arrow(alice, john, "Hello John, how are you?"),
          sequence.loop("HealthCheck", [
              sequence.message_arrow(john, john, "Fight against hypochondria")
          ]),
          sequence.note(john, "Rational thoughts!", note_position.right_of()),
          sequence.message_dotted_arrow(john, alice, "Great!"),
          sequence.message_arrow(john, bob, "How about you?"),
          sequence.message_dotted_arrow(bob, john, "Jolly good!")
      ]).write()
      expected = """sequenceDiagram
    autonumber
    Alice->>John: Hello John, how are you?
    loop HealthCheck
        John->>John: Fight against hypochondria
    end
    note right of John : Rational thoughts!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
"""
      assert actual == expected
  def test_actor_links(self):
      alice, john = "Alice", "John"
      actual = siren.sequence([
          sequence.participant(alice), 
          sequence.participant(john), 
          sequence.link(alice, "Dashboard", "https://dashboard.contoso.com/alice"),
          sequence.link(alice, "Wiki", "https://wiki.contoso.com/alice"),
          sequence.link(john, "Dashboard", "https://dashboard.contoso.com/john"),
          sequence.link(john, "Wiki", "https://wiki.contoso.com/john"),
          sequence.message_arrow(alice, john, "Hello John, how are you?")
      ]).write()
      expected = """sequenceDiagram
    participant Alice
    participant John
    link Alice: Dashboard @ https://dashboard.contoso.com/alice
    link Alice: Wiki @ https://wiki.contoso.com/alice
    link John: Dashboard @ https://dashboard.contoso.com/john
    link John: Wiki @ https://wiki.contoso.com/john
    Alice->>John: Hello John, how are you?
"""
      assert actual == expected