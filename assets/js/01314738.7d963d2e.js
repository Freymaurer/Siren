"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[1248],{4998:(r,n,e)=>{e.r(n),e.d(n,{assets:()=>s,contentTitle:()=>c,default:()=>w,frontMatter:()=>i,metadata:()=>h,toc:()=>d});var t=e(4848),a=e(8453),o=e(1470),l=e(9365);const i={sidebar_label:"Flowchart"},c=void 0,h={id:"Graphs/FlowChart",title:"FlowChart",description:"The following classes can be useful when creating flowcharts:",source:"@site/docs/Graphs/FlowChart.mdx",sourceDirName:"Graphs",slug:"/Graphs/FlowChart",permalink:"/Siren/docs/Graphs/FlowChart",draft:!1,unlisted:!1,editUrl:"https://github.com/Freymaurer/Siren/tree/main/docs/docs/Graphs/FlowChart.mdx",tags:[],version:"current",frontMatter:{sidebar_label:"Flowchart"},sidebar:"docsSidebar",previous:{title:"Entity Relationship Diagram",permalink:"/Siren/docs/Graphs/ErDiagram"},next:{title:"Gantt",permalink:"/Siren/docs/Graphs/Gantt"}},s={},d=[{value:"With Title",id:"with-title",level:2},{value:"Different Lengths",id:"different-lengths",level:2},{value:"Subgraphs",id:"subgraphs",level:2},{value:"Subgraph direction",id:"subgraph-direction",level:2},{value:"Markdown strings",id:"markdown-strings",level:2},{value:"To the Moon",id:"to-the-moon",level:2}];function u(r){const n={code:"code",h2:"h2",li:"li",mermaid:"mermaid",p:"p",pre:"pre",ul:"ul",...(0,a.R)(),...r.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(n.p,{children:"The following classes can be useful when creating flowcharts:"}),"\n",(0,t.jsxs)(n.ul,{children:["\n",(0,t.jsx)(n.li,{children:(0,t.jsx)(n.code,{children:"siren"})}),"\n",(0,t.jsx)(n.li,{children:(0,t.jsx)(n.code,{children:"flowchart"})}),"\n",(0,t.jsx)(n.li,{children:(0,t.jsx)(n.code,{children:"direction"})}),"\n",(0,t.jsx)(n.li,{children:(0,t.jsx)(n.code,{children:"flowchartConfig"})}),"\n"]}),"\n",(0,t.jsx)(n.h2,{id:"with-title",children:"With Title"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.lr, [\r\n    flowchart.node("id1", "This is the text in the box")\r\n])\r\n|> siren.withTitle("Node with text")\r\n|> siren.write\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'string graph = siren.flowchart(direction.lr, [\r\n    flowchart.node("id1", "This is the text in the box")\r\n]).withTitle("Node with text").write();\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.lr(), [\r\n    flowchart.node("id1", "This is the text in the box")\r\n]).with_title("Node with text").write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.lr, [\r\n    flowchart.node("id1", "This is the text in the box")\r\n]).withTitle("Node with text").write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:"---\r\ntitle: Node with text\r\n---\r\nflowchart LR\r\n    id1[This is the text in the box]"})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:"---\r\ntitle: Node with text\r\n---\r\nflowchart LR\r\n    id1[This is the text in the box]\n"})})})]}),"\n",(0,t.jsx)(n.h2,{id:"different-lengths",children:"Different Lengths"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.td, [\r\n    flowchart.node(a, "Start")\r\n    flowchart.nodeRhombus(b, "Is it?")\r\n    flowchart.node(c, "OK")\r\n    flowchart.node(d, "Rethink")\r\n    flowchart.node(e, "End")\r\n    flowchart.linkArrow(a, b)\r\n    flowchart.linkArrow(b, c, "Yes")\r\n    flowchart.linkArrow(c, d)\r\n    flowchart.linkArrow(d, b)\r\n    flowchart.linkArrow(b, e, "No", 3)\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'(string a, string b, string c, string d, string e) = ("A", "B", "C", "D", "E");\r\nSirenElement graph = siren.flowchart(direction.td, [\r\n    flowchart.node(a, "Start"),\r\n    flowchart.nodeRhombus(b, "Is it?"),\r\n    flowchart.node(c, "OK"),\r\n    flowchart.node(d, "Rethink"),\r\n    flowchart.node(e, "End"),\r\n    flowchart.linkArrow(a, b),\r\n    flowchart.linkArrow(b, c, "Yes"),\r\n    flowchart.linkArrow(c, d),\r\n    flowchart.linkArrow(d, b),\r\n    flowchart.linkArrow(b, e, "No", 3),\r\n]);\r\nstring actual =\r\n    graph.write();\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.td(), [\r\n  flowchart.node("A", "Start"), \r\n  flowchart.node_rhombus("B", "Is it?"), \r\n  flowchart.node("C", "OK"), \r\n  flowchart.node("D", "Rethink"), \r\n  flowchart.node("E", "End"), \r\n  flowchart.link_arrow("A", "B"), \r\n  flowchart.link_arrow("B", "C", "Yes"), \r\n  flowchart.link_arrow("C", "D"), \r\n  flowchart.link_arrow("D", "B"), \r\n  flowchart.link_arrow("B", "E", "No", 3)\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.td, [\r\n    flowchart.node("A", "Start"), \r\n    flowchart.nodeRhombus("B", "Is it?"), \r\n    flowchart.node("C", "OK"), \r\n    flowchart.node("D", "Rethink"), \r\n    flowchart.node("E", "End"), \r\n    flowchart.linkArrow("A", "B"), \r\n    flowchart.linkArrow("B", "C", "Yes"), \r\n    flowchart.linkArrow("C", "D"), \r\n    flowchart.linkArrow("D", "B"), \r\n    flowchart.linkArrow("B", "E", "No", 3)\r\n]).write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:"flowchart TD\r\n    A[Start]\r\n    B{Is it?}\r\n    C[OK]\r\n    D[Rethink]\r\n    E[End]\r\n    A--\x3eB\r\n    B--\x3e|Yes|C\r\n    C--\x3eD\r\n    D--\x3eB\r\n    B----\x3e|No|E"})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:"flowchart TD\r\n    A[Start]\r\n    B{Is it?}\r\n    C[OK]\r\n    D[Rethink]\r\n    E[End]\r\n    A--\x3eB\r\n    B--\x3e|Yes|C\r\n    C--\x3eD\r\n    D--\x3eB\r\n    B----\x3e|No|E\n"})})})]}),"\n",(0,t.jsx)(n.h2,{id:"subgraphs",children:"Subgraphs"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.tb, [\r\n    flowchart.linkArrow(c1, a2)\r\n    flowchart.subgraph("one", [\r\n        flowchart.linkArrow(a1,a2)\r\n    ])\r\n    flowchart.subgraph("two", [\r\n        flowchart.linkArrow(b1,b2)\r\n    ])\r\n    flowchart.subgraph("three", [\r\n        flowchart.linkArrow(c1,c2)\r\n    ])\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'(string c1, string c2, string b1, string b2, string a1, string a2) = ("c1", "c2", "b1", "b2", "a1", "a2");\r\nSirenElement graph = siren.flowchart(direction.tb, [\r\n    flowchart.linkArrow(c1, a2),\r\n    flowchart.subgraph("one", [\r\n        flowchart.linkArrow(a1,a2)\r\n    ]),\r\n    flowchart.subgraph("two", [\r\n        flowchart.linkArrow(b1,b2)\r\n    ]),\r\n    flowchart.subgraph("three", [\r\n        flowchart.linkArrow(c1,c2)\r\n    ])\r\n\r\n]);\r\nstring actual =\r\n    graph.write();\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.tb(), [\r\n  flowchart.link_arrow("c1", "a2"), \r\n  flowchart.subgraph("one", [flowchart.link_arrow("a1", "a2")]), \r\n  flowchart.subgraph("two", [flowchart.link_arrow("b1", "b2")]), \r\n  flowchart.subgraph("three", [flowchart.link_arrow("c1", "c2")])\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.tb, [\r\n    flowchart.linkArrow("c1", "a2"), \r\n    flowchart.subgraph("one", [flowchart.linkArrow("a1", "a2")]), \r\n    flowchart.subgraph("two", [flowchart.linkArrow("b1", "b2")]), \r\n    flowchart.subgraph("three", [flowchart.linkArrow("c1", "c2")])\r\n]).write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:"flowchart TB\r\n    c1--\x3ea2\r\n    subgraph one\r\n        a1--\x3ea2\r\n    end\r\n    subgraph two\r\n        b1--\x3eb2\r\n    end\r\n    subgraph three\r\n        c1--\x3ec2\r\n    end"})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:"flowchart TB\r\n    c1--\x3ea2\r\n    subgraph one\r\n        a1--\x3ea2\r\n    end\r\n    subgraph two\r\n        b1--\x3eb2\r\n    end\r\n    subgraph three\r\n        c1--\x3ec2\r\n    end\n"})})})]}),"\n",(0,t.jsx)(n.h2,{id:"subgraph-direction",children:"Subgraph direction"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("subgraph1", [\r\n        flowchart.directionTB\r\n        flowchart.node(top1)\r\n        flowchart.node(bot1)\r\n        flowchart.linkArrow(top1, bot1)\r\n    ])\r\n    flowchart.subgraph("subgraph2", [\r\n        flowchart.directionTB\r\n        flowchart.node(top2)\r\n        flowchart.node(bot2)\r\n        flowchart.linkArrow(top2, bot2)\r\n    ])\r\n    flowchart.linkArrow(outside, "subgraph1")\r\n    flowchart.linkArrow(outside, top2, addedLength = 2)\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'(string outside, string top1, string bot1, string top2, string bot2) = ("outside", "top1", "bottom1", "top2", "bottom2");\r\nSirenElement graph = siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("subgraph1", [\r\n        flowchart.directionTB,\r\n        flowchart.node(top1),\r\n        flowchart.node(bot1),\r\n        flowchart.linkArrow(top1, bot1)\r\n    ]),\r\n    flowchart.subgraph("subgraph2", [\r\n        flowchart.directionTB,\r\n        flowchart.node(top2),\r\n        flowchart.node(bot2),\r\n        flowchart.linkArrow(top2, bot2)\r\n    ]),\r\n    flowchart.linkArrow(outside, "subgraph1"),\r\n    flowchart.linkArrow(outside, top2, addedLength: 2),\r\n]);\r\nstring actual = graph.write();\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.lr(), [\r\n  flowchart.subgraph("subgraph1", [\r\n      flowchart.direction_tb(), \r\n      flowchart.node("top1"), \r\n      flowchart.node("bottom1"), \r\n      flowchart.link_arrow("top1", "bottom1")\r\n  ]), \r\n  flowchart.subgraph("subgraph2", [\r\n      flowchart.direction_tb(), \r\n      flowchart.node("top2"), \r\n      flowchart.node("bottom2"), \r\n      flowchart.link_arrow("top2", "bottom2")\r\n  ]), \r\n  flowchart.link_arrow("outside", "subgraph1"), \r\n  flowchart.link_arrow("outside", "top2", None, 2)\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("subgraph1", [\r\n        flowchart.directionTB, \r\n        flowchart.node("top1"), \r\n        flowchart.node("bottom1"), \r\n        flowchart.linkArrow("top1", "bottom1")\r\n    ]), \r\n    flowchart.subgraph("subgraph2", [\r\n        flowchart.directionTB, \r\n        flowchart.node("top2"), \r\n        flowchart.node("bottom2"), \r\n        flowchart.linkArrow("top2", "bottom2")\r\n    ]), \r\n    flowchart.linkArrow("outside", "subgraph1"), \r\n    flowchart.linkArrow("outside", "top2", null, 2)\r\n]).write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:"flowchart LR\r\n    subgraph subgraph1\r\n        direction TB\r\n        top1[top1]\r\n        bottom1[bottom1]\r\n        top1--\x3ebottom1\r\n    end\r\n    subgraph subgraph2\r\n        direction TB\r\n        top2[top2]\r\n        bottom2[bottom2]\r\n        top2--\x3ebottom2\r\n    end\r\n    outside--\x3esubgraph1\r\n    outside---\x3etop2"})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:"flowchart LR\r\n    subgraph subgraph1\r\n        direction TB\r\n        top1[top1]\r\n        bottom1[bottom1]\r\n        top1--\x3ebottom1\r\n    end\r\n    subgraph subgraph2\r\n        direction TB\r\n        top2[top2]\r\n        bottom2[bottom2]\r\n        top2--\x3ebottom2\r\n    end\r\n    outside--\x3esubgraph1\r\n    outside---\x3etop2\n"})})})]}),"\n",(0,t.jsx)(n.h2,{id:"markdown-strings",children:"Markdown strings"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("One", [\r\n        flowchart.nodeRound("a", formatting.markdown(@"The **cat**\r\nin the hat")\r\n        )\r\n        flowchart.nodeRhombus("b", formatting.markdown(@"The **dog** in the hog"))\r\n        flowchart.linkArrow("a","b", formatting.markdown("Bold **edge label**"))\r\n    ])\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'SirenElement graph = siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("One", [\r\n        flowchart.nodeRound("a", formatting.markdown(@"The **cat**\r\nin the hat")\r\n        ),\r\n        flowchart.nodeRhombus("b", formatting.markdown(@"The **dog** in the hog")),\r\n        flowchart.linkArrow("a","b", formatting.markdown("Bold **edge label**"))\r\n    ]),\r\n]);\r\nstring actual = siren.write(graph);\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.lr(), [\r\n    flowchart.subgraph("One", [\r\n        flowchart.node_round("a", formatting.markdown("""The **cat**\r\nin the hat""")), \r\n        flowchart.node_rhombus("b", formatting.markdown("The **dog** in the hog")), \r\n        flowchart.link_arrow("a", "b", formatting.markdown("Bold **edge label**"))\r\n    ])\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.lr, [\r\n    flowchart.subgraph("One", [\r\n        flowchart.nodeRound("a", formatting.markdown(`The **cat**\r\nin the hat`)), \r\n        flowchart.nodeRhombus("b", formatting.markdown("The **dog** in the hog")), \r\n        flowchart.linkArrow("a", "b", formatting.markdown("Bold **edge label**"))\r\n    ])\r\n]).write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:'flowchart LR\r\n    subgraph One\r\n        a(""`The **cat**\r\nin the hat`"")\r\n        b{""`The **dog** in the hog`""}\r\n        a--\x3e|""`Bold **edge label**`""|b\r\n    end'})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:'flowchart LR\r\n    subgraph One\r\n        a(""`The **cat**\r\nin the hat`"")\r\n        b{""`The **dog** in the hog`""}\r\n        a--\x3e|""`Bold **edge label**`""|b\r\n    end\n'})})})]}),"\n",(0,t.jsx)(n.h2,{id:"to-the-moon",children:"To the Moon"}),"\n",(0,t.jsxs)(o.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'siren.flowchart(direction.bt, [\r\n    flowchart.subgraph("space", [\r\n        flowchart.directionBT\r\n        flowchart.linkDottedArrow("earth", "moon", formatting.unicode("\ud83d\ude80"), 6)\r\n        flowchart.nodeRound("moon")\r\n        flowchart.subgraph("atmosphere",[\r\n            flowchart.nodeCircle("earth")\r\n        ])\r\n    ])\r\n])\r\n|> siren.write\n'})})}),(0,t.jsx)(l.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'SirenElement graph = siren.flowchart(direction.bt, [\r\n    flowchart.subgraph("space", [\r\n        flowchart.directionBT,\r\n        flowchart.linkDottedArrow("earth", "moon", formatting.unicode("\ud83d\ude80"), 6),\r\n        flowchart.nodeRound("moon"),\r\n        flowchart.subgraph("atmosphere",[\r\n            flowchart.nodeCircle("earth")\r\n        ])\r\n    ])\r\n]);\r\nstring actual = siren.write(graph);\n'})})}),(0,t.jsx)(l.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-py",children:'siren.flowchart(direction.bt(), [\r\n    flowchart.subgraph("space", [\r\n        flowchart.direction_bt(), \r\n        flowchart.link_dotted_arrow("earth", "moon", formatting.unicode("\ud83d\ude80"), 6), \r\n        flowchart.node_round("moon"), \r\n        flowchart.subgraph("atmosphere", [\r\n            flowchart.node_circle("earth")\r\n        ])\r\n    ])\r\n]).write()\n'})})}),(0,t.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'siren.flowchart(direction.bt, [\r\n    flowchart.subgraph("space", [\r\n        flowchart.directionBT, \r\n        flowchart.linkDottedArrow("earth", "moon", formatting.unicode("\ud83d\ude80"), 6), \r\n        flowchart.nodeRound("moon"), \r\n        flowchart.subgraph("atmosphere", [\r\n            flowchart.nodeCircle("earth")\r\n        ])\r\n    ])\r\n]).write();\n'})})})]}),"\n",(0,t.jsxs)(o.A,{children:[(0,t.jsx)(l.A,{value:"graph",label:"Graph",children:(0,t.jsx)(n.mermaid,{value:'flowchart BT\r\n    subgraph space\r\n        direction BT\r\n        earth-......->|""\ud83d\ude80""|moon\r\n        moon(moon)\r\n        subgraph atmosphere\r\n            earth((earth))\r\n        end\r\n    end'})}),(0,t.jsx)(l.A,{value:"output",label:"Output",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yml",children:'flowchart BT\r\n    subgraph space\r\n        direction BT\r\n        earth-......->|""\ud83d\ude80""|moon\r\n        moon(moon)\r\n        subgraph atmosphere\r\n            earth((earth))\r\n        end\r\n    end\n'})})})]})]})}function w(r={}){const{wrapper:n}={...(0,a.R)(),...r.components};return n?(0,t.jsx)(n,{...r,children:(0,t.jsx)(u,{...r})}):u(r)}},9365:(r,n,e)=>{e.d(n,{A:()=>l});e(6540);var t=e(4164);const a={tabItem:"tabItem_Ymn6"};var o=e(4848);function l(r){let{children:n,hidden:e,className:l}=r;return(0,o.jsx)("div",{role:"tabpanel",className:(0,t.A)(a.tabItem,l),hidden:e,children:n})}},1470:(r,n,e)=>{e.d(n,{A:()=>v});var t=e(6540),a=e(4164),o=e(3104),l=e(6347),i=e(205),c=e(7485),h=e(1682),s=e(9466);function d(r){return t.Children.toArray(r).filter((r=>"\n"!==r)).map((r=>{if(!r||(0,t.isValidElement)(r)&&function(r){const{props:n}=r;return!!n&&"object"==typeof n&&"value"in n}(r))return r;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof r.type?r.type:r.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}function u(r){const{values:n,children:e}=r;return(0,t.useMemo)((()=>{const r=n??function(r){return d(r).map((r=>{let{props:{value:n,label:e,attributes:t,default:a}}=r;return{value:n,label:e,attributes:t,default:a}}))}(e);return function(r){const n=(0,h.X)(r,((r,n)=>r.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((r=>r.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(r),r}),[n,e])}function w(r){let{value:n,tabValues:e}=r;return e.some((r=>r.value===n))}function p(r){let{queryString:n=!1,groupId:e}=r;const a=(0,l.W6)(),o=function(r){let{queryString:n=!1,groupId:e}=r;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!e)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return e??null}({queryString:n,groupId:e});return[(0,c.aZ)(o),(0,t.useCallback)((r=>{if(!o)return;const n=new URLSearchParams(a.location.search);n.set(o,r),a.replace({...a.location,search:n.toString()})}),[o,a])]}function f(r){const{defaultValue:n,queryString:e=!1,groupId:a}=r,o=u(r),[l,c]=(0,t.useState)((()=>function(r){let{defaultValue:n,tabValues:e}=r;if(0===e.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!w({value:n,tabValues:e}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${e.map((r=>r.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const t=e.find((r=>r.default))??e[0];if(!t)throw new Error("Unexpected error: 0 tabValues");return t.value}({defaultValue:n,tabValues:o}))),[h,d]=p({queryString:e,groupId:a}),[f,b]=function(r){let{groupId:n}=r;const e=function(r){return r?`docusaurus.tab.${r}`:null}(n),[a,o]=(0,s.Dv)(e);return[a,(0,t.useCallback)((r=>{e&&o.set(r)}),[e,o])]}({groupId:a}),g=(()=>{const r=h??f;return w({value:r,tabValues:o})?r:null})();(0,i.A)((()=>{g&&c(g)}),[g]);return{selectedValue:l,selectValue:(0,t.useCallback)((r=>{if(!w({value:r,tabValues:o}))throw new Error(`Can't select invalid tab value=${r}`);c(r),d(r),b(r)}),[d,b,o]),tabValues:o}}var b=e(2303);const g={tabList:"tabList__CuJ",tabItem:"tabItem_LNqP"};var m=e(4848);function x(r){let{className:n,block:e,selectedValue:t,selectValue:l,tabValues:i}=r;const c=[],{blockElementScrollPositionUntilNextRender:h}=(0,o.a_)(),s=r=>{const n=r.currentTarget,e=c.indexOf(n),a=i[e].value;a!==t&&(h(n),l(a))},d=r=>{let n=null;switch(r.key){case"Enter":s(r);break;case"ArrowRight":{const e=c.indexOf(r.currentTarget)+1;n=c[e]??c[0];break}case"ArrowLeft":{const e=c.indexOf(r.currentTarget)-1;n=c[e]??c[c.length-1];break}}n?.focus()};return(0,m.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,a.A)("tabs",{"tabs--block":e},n),children:i.map((r=>{let{value:n,label:e,attributes:o}=r;return(0,m.jsx)("li",{role:"tab",tabIndex:t===n?0:-1,"aria-selected":t===n,ref:r=>c.push(r),onKeyDown:d,onClick:s,...o,className:(0,a.A)("tabs__item",g.tabItem,o?.className,{"tabs__item--active":t===n}),children:e??n},n)}))})}function j(r){let{lazy:n,children:e,selectedValue:a}=r;const o=(Array.isArray(e)?e:[e]).filter(Boolean);if(n){const r=o.find((r=>r.props.value===a));return r?(0,t.cloneElement)(r,{className:"margin-top--md"}):null}return(0,m.jsx)("div",{className:"margin-top--md",children:o.map(((r,n)=>(0,t.cloneElement)(r,{key:n,hidden:r.props.value!==a})))})}function A(r){const n=f(r);return(0,m.jsxs)("div",{className:(0,a.A)("tabs-container",g.tabList),children:[(0,m.jsx)(x,{...r,...n}),(0,m.jsx)(j,{...r,...n})]})}function v(r){const n=(0,b.A)();return(0,m.jsx)(A,{...r,children:d(r.children)},String(n))}},8453:(r,n,e)=>{e.d(n,{R:()=>l,x:()=>i});var t=e(6540);const a={},o=t.createContext(a);function l(r){const n=t.useContext(o);return t.useMemo((function(){return"function"==typeof r?r(n):{...n,...r}}),[n,r])}function i(r){let n;return n=r.disableParentContext?"function"==typeof r.components?r.components(a):r.components||a:l(r.components),t.createElement(o.Provider,{value:n},r.children)}}}]);