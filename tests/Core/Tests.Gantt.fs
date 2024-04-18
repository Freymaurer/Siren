module Tests.Gantt

open Fable.Pyxpecto
open Siren

let private tests_task = testList "task" [
    testCase "minimal" <| fun _ ->
        let apple = "apple"
        let actual =
            siren.gantt [
                gantt.task (apple,apple, "0", "6d")
                gantt.taskStartEnd("banana", ganttTime.after apple, "6d")
                gantt.taskEnd("cherry", "6d")
            ]
            |> siren.write
        let expected = """gantt
    apple : apple, 0, 6d
    banana : after apple, 6d
    cherry : 6d
"""
        Expect.trimEqual actual expected ""
    testCase "tags" <| fun _ ->
        let apple = "apple"
        let actual =
            siren.gantt [
                gantt.task (apple,apple, "0", "6d", [ganttTags.active])
                gantt.taskStartEnd("banana", ganttTime.after apple, "6d", [ganttTags.crit])
                gantt.taskEnd("cherry", "6d", [ganttTags.done'])
                gantt.taskEnd("coconut", "6d", [ganttTags.done'; ganttTags.crit; ganttTags.milestone; ganttTags.active])
            ]
            |> siren.write
        let expected = """gantt
    apple : active, apple, 0, 6d
    banana : crit, after apple, 6d
    cherry : done, 6d
    coconut : done, crit, milestone, active, 6d
"""
        Expect.trimEqual actual expected ""
    testCase "milestone" <| fun _ ->
        let apple = "apple"
        let actual =
            siren.gantt [
                gantt.milestone (apple,apple, "0", "6d", [ganttTags.active])
                gantt.milestoneStartEnd("banana", ganttTime.after apple, "6d", [ganttTags.crit])
                gantt.milestoneEnd("cherry", "6d", [ganttTags.done'])
                gantt.milestoneEnd("coconut", "6d", [ganttTags.done'; ganttTags.crit; ganttTags.milestone; ganttTags.active])
            ]
            |> siren.write
        let expected = """gantt
    apple : milestone, active, apple, 0, 6d
    banana : milestone, crit, after apple, 6d
    cherry : milestone, done, 6d
    coconut : milestone, done, crit, active, 6d
"""
        Expect.trimEqual actual expected ""
]

let private test_complex = testCase "complex" <| fun _ ->
    let actual =
        siren.gantt [
            gantt.dateFormat "YYYY-MM-DD"
            gantt.title "Adding GANTT diagram functionality to mermaid"
            gantt.excludes "weekends"
            gantt.comment """(`excludes` accepts specific dates in YYYY-MM-DD format, days of the week ("sunday") or "weekends", but not the word "weekdays".)"""

            let des1 = "des1"
            gantt.section "A section"
            gantt.task("Completed task", des1, "2014-01-06", "2014-01-08", [ganttTags.done'])
            gantt.task("Active task", "des2", "2014-01-09", "3d", [ganttTags.active])
            gantt.task("Future task", "des3", "after des2", "5d")
            gantt.task("Future task2", "des4", "after des3", "5d")

            let isadded = "isadded"
            gantt.section "section Critical tasks"
            gantt.taskStartEnd("Completed task in the critical line", "2014-01-06", "24h", [ganttTags.done'; ganttTags.crit])
            gantt.taskStartEnd("Implement parser and jison", ganttTime.after des1, "2d", [ganttTags.done'; ganttTags.crit])
            gantt.taskEnd("Create tests for parser", "3d", [ganttTags.active; ganttTags.crit])
            gantt.taskEnd("Future task in critical line", "2d", [ganttTags.crit])
            gantt.taskEnd("Create tests for renderer", "2d")
            gantt.taskEnd("Add to mermaid", ganttTime.until isadded)
            gantt.milestone("Functionality added", isadded, "2014-01-25", "0d")

            let a1 = "a1"
            let doc1 = "doc1"
            gantt.section "section Documentation"
            gantt.task("Describe gantt syntax", a1, ganttTime.after des1, "3d", [ganttTags.active])
            gantt.taskStartEnd("Add gantt diagram to demo page", ganttTime.after a1, "20h")
            gantt.task("Add another diagram to demo page", doc1, ganttTime.after a1, "48h")

            gantt.section "Last section"
            gantt.taskStartEnd("Describe gantt syntax", ganttTime.after doc1, "3d")
            gantt.taskEnd("Add gantt diagram to demo page", "20h")
            gantt.taskEnd("Add another diagram to demo page", "48h")
        ]
        |> siren.write
    let expected = """gantt
    dateFormat YYYY-MM-DD
    title Adding GANTT diagram functionality to mermaid
    excludes weekends
    %% (`excludes` accepts specific dates in YYYY-MM-DD format, days of the week ("sunday") or "weekends", but not the word "weekdays".)
    section A section
    Completed task : done, des1, 2014-01-06, 2014-01-08
    Active task : active, des2, 2014-01-09, 3d
    Future task : des3, after des2, 5d
    Future task2 : des4, after des3, 5d
    section section Critical tasks
    Completed task in the critical line : done, crit, 2014-01-06, 24h
    Implement parser and jison : done, crit, after des1, 2d
    Create tests for parser : active, crit, 3d
    Future task in critical line : crit, 2d
    Create tests for renderer : 2d
    Add to mermaid : until isadded
    Functionality added : milestone, isadded, 2014-01-25, 0d
    section section Documentation
    Describe gantt syntax : active, a1, after des1, 3d
    Add gantt diagram to demo page : after a1, 20h
    Add another diagram to demo page : doc1, after a1, 48h
    section Last section
    Describe gantt syntax : after doc1, 3d
    Add gantt diagram to demo page : 20h
    Add another diagram to demo page : 48h
"""
    Expect.trimEqual actual expected ""

let main = testList "Gantt" [
    tests_task
    test_complex
]

