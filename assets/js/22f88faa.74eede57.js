"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[9221],{5047:(e,n,r)=>{r.r(n),r.d(n,{assets:()=>c,contentTitle:()=>i,default:()=>p,frontMatter:()=>o,metadata:()=>u,toc:()=>d});var a=r(4848),t=r(8453),s=r(1470),l=r(9365);const o={sidebar_label:"Sankey"},i=void 0,u={id:"Graphs/Sankey",title:"Sankey",description:"The following classes can be useful when creating requirement diagrams:",source:"@site/docs/Graphs/Sankey.mdx",sourceDirName:"Graphs",slug:"/Graphs/Sankey",permalink:"/Siren/docs/Graphs/Sankey",draft:!1,unlisted:!1,editUrl:"https://github.com/Freymaurer/Siren/tree/main/docs/docs/Graphs/Sankey.mdx",tags:[],version:"current",frontMatter:{sidebar_label:"Sankey"},sidebar:"docsSidebar",previous:{title:"Requirement Chart",permalink:"/Siren/docs/Graphs/Requirement"},next:{title:"Sequence Diagram",permalink:"/Siren/docs/Graphs/Sequence"}},c={},d=[{value:"Bio conversion",id:"bio-conversion",level:2}];function h(e){const n={code:"code",h2:"h2",li:"li",mermaid:"mermaid",p:"p",pre:"pre",ul:"ul",...(0,t.R)(),...e.components};return(0,a.jsxs)(a.Fragment,{children:[(0,a.jsx)(n.p,{children:"The following classes can be useful when creating requirement diagrams:"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsx)(n.li,{children:(0,a.jsx)(n.code,{children:"siren"})}),"\n",(0,a.jsx)(n.li,{children:(0,a.jsx)(n.code,{children:"sankey"})}),"\n",(0,a.jsx)(n.li,{children:(0,a.jsx)(n.code,{children:"sankeyConfig"})}),"\n"]}),"\n",(0,a.jsx)(n.h2,{id:"bio-conversion",children:"Bio conversion"}),"\n",(0,a.jsxs)(s.A,{groupId:"preferred-lang",queryString:!0,children:[(0,a.jsx)(l.A,{value:"fsharp",label:"F#",children:(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-fsharp",children:'siren.sankey [\r\n    sankey.links("Bio-conversion", [\r\n        "Losses", 26.862\r\n        "Solid", 280.322\r\n        "Gas", 81.144\r\n    ])\r\n]\r\n|> siren.write\n'})})}),(0,a.jsx)(l.A,{value:"csharp",label:"C#",children:(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:'siren.sankey([\r\n    sankey.links("Bio-conversion", [\r\n        ("Losses", 26.862),\r\n        ("Solid", 280.322),\r\n        ("Gas", 81.144)\r\n    ])\r\n]).write();\n'})})}),(0,a.jsx)(l.A,{value:"py",label:"Python",children:(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-py",children:'siren.sankey([\r\n    sankey.links("Bio-conversion", [\r\n        ("Losses", 26.862),\r\n        ("Solid", 280.322),\r\n        ("Gas", 81.144)\r\n    ])\r\n]).write()\n'})})}),(0,a.jsx)(l.A,{value:"js",label:"JavaScript",children:(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-js",children:'siren.sankey([\r\n    sankey.links("Bio-conversion", [\r\n        ["Losses", 26.862],\r\n        ["Solid", 280.322],\r\n        ["Gas", 81.144]\r\n    ])\r\n]).write();\n'})})})]}),"\n","\n",(0,a.jsxs)(s.A,{children:[(0,a.jsx)(l.A,{value:"graph",label:"Graph",children:(0,a.jsx)(n.mermaid,{value:'sankey-beta\r\n"Bio-conversion","Losses",26.862000\r\n"Bio-conversion","Solid",280.322000\r\n"Bio-conversion","Gas",81.144000'})}),(0,a.jsx)(l.A,{value:"output",label:"Output",children:(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-yml",children:'sankey-beta\r\n"Bio-conversion","Losses",26.862000\r\n"Bio-conversion","Solid",280.322000\r\n"Bio-conversion","Gas",81.144000\n'})})})]})]})}function p(e={}){const{wrapper:n}={...(0,t.R)(),...e.components};return n?(0,a.jsx)(n,{...e,children:(0,a.jsx)(h,{...e})}):h(e)}},9365:(e,n,r)=>{r.d(n,{A:()=>l});r(6540);var a=r(4164);const t={tabItem:"tabItem_Ymn6"};var s=r(4848);function l(e){let{children:n,hidden:r,className:l}=e;return(0,s.jsx)("div",{role:"tabpanel",className:(0,a.A)(t.tabItem,l),hidden:r,children:n})}},1470:(e,n,r)=>{r.d(n,{A:()=>k});var a=r(6540),t=r(4164),s=r(3104),l=r(6347),o=r(205),i=r(7485),u=r(1682),c=r(9466);function d(e){return a.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,a.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}function h(e){const{values:n,children:r}=e;return(0,a.useMemo)((()=>{const e=n??function(e){return d(e).map((e=>{let{props:{value:n,label:r,attributes:a,default:t}}=e;return{value:n,label:r,attributes:a,default:t}}))}(r);return function(e){const n=(0,u.X)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,r])}function p(e){let{value:n,tabValues:r}=e;return r.some((e=>e.value===n))}function m(e){let{queryString:n=!1,groupId:r}=e;const t=(0,l.W6)(),s=function(e){let{queryString:n=!1,groupId:r}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!r)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return r??null}({queryString:n,groupId:r});return[(0,i.aZ)(s),(0,a.useCallback)((e=>{if(!s)return;const n=new URLSearchParams(t.location.search);n.set(s,e),t.replace({...t.location,search:n.toString()})}),[s,t])]}function b(e){const{defaultValue:n,queryString:r=!1,groupId:t}=e,s=h(e),[l,i]=(0,a.useState)((()=>function(e){let{defaultValue:n,tabValues:r}=e;if(0===r.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!p({value:n,tabValues:r}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${r.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const a=r.find((e=>e.default))??r[0];if(!a)throw new Error("Unexpected error: 0 tabValues");return a.value}({defaultValue:n,tabValues:s}))),[u,d]=m({queryString:r,groupId:t}),[b,f]=function(e){let{groupId:n}=e;const r=function(e){return e?`docusaurus.tab.${e}`:null}(n),[t,s]=(0,c.Dv)(r);return[t,(0,a.useCallback)((e=>{r&&s.set(e)}),[r,s])]}({groupId:t}),v=(()=>{const e=u??b;return p({value:e,tabValues:s})?e:null})();(0,o.A)((()=>{v&&i(v)}),[v]);return{selectedValue:l,selectValue:(0,a.useCallback)((e=>{if(!p({value:e,tabValues:s}))throw new Error(`Can't select invalid tab value=${e}`);i(e),d(e),f(e)}),[d,f,s]),tabValues:s}}var f=r(2303);const v={tabList:"tabList__CuJ",tabItem:"tabItem_LNqP"};var g=r(4848);function x(e){let{className:n,block:r,selectedValue:a,selectValue:l,tabValues:o}=e;const i=[],{blockElementScrollPositionUntilNextRender:u}=(0,s.a_)(),c=e=>{const n=e.currentTarget,r=i.indexOf(n),t=o[r].value;t!==a&&(u(n),l(t))},d=e=>{let n=null;switch(e.key){case"Enter":c(e);break;case"ArrowRight":{const r=i.indexOf(e.currentTarget)+1;n=i[r]??i[0];break}case"ArrowLeft":{const r=i.indexOf(e.currentTarget)-1;n=i[r]??i[i.length-1];break}}n?.focus()};return(0,g.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,t.A)("tabs",{"tabs--block":r},n),children:o.map((e=>{let{value:n,label:r,attributes:s}=e;return(0,g.jsx)("li",{role:"tab",tabIndex:a===n?0:-1,"aria-selected":a===n,ref:e=>i.push(e),onKeyDown:d,onClick:c,...s,className:(0,t.A)("tabs__item",v.tabItem,s?.className,{"tabs__item--active":a===n}),children:r??n},n)}))})}function y(e){let{lazy:n,children:r,selectedValue:t}=e;const s=(Array.isArray(r)?r:[r]).filter(Boolean);if(n){const e=s.find((e=>e.props.value===t));return e?(0,a.cloneElement)(e,{className:"margin-top--md"}):null}return(0,g.jsx)("div",{className:"margin-top--md",children:s.map(((e,n)=>(0,a.cloneElement)(e,{key:n,hidden:e.props.value!==t})))})}function j(e){const n=b(e);return(0,g.jsxs)("div",{className:(0,t.A)("tabs-container",v.tabList),children:[(0,g.jsx)(x,{...e,...n}),(0,g.jsx)(y,{...e,...n})]})}function k(e){const n=(0,f.A)();return(0,g.jsx)(j,{...e,children:d(e.children)},String(n))}},8453:(e,n,r)=>{r.d(n,{R:()=>l,x:()=>o});var a=r(6540);const t={},s=a.createContext(t);function l(e){const n=a.useContext(s);return a.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(t):e.components||t:l(e.components),a.createElement(s.Provider,{value:n},e.children)}}}]);