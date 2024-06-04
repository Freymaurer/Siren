"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[387],{4566:(e,n,r)=>{r.r(n),r.d(n,{assets:()=>u,contentTitle:()=>l,default:()=>f,frontMatter:()=>o,metadata:()=>c,toc:()=>h});var t=r(4848),a=r(8453),i=r(1470),s=r(9365);const o={sidebar_label:"Config",sidebar_position:2},l="Config",c={id:"config",title:"Config",description:"Config variables are a concept used to adjust both rendering and behavior of some graphs.",source:"@site/docs/config.mdx",sourceDirName:".",slug:"/config",permalink:"/Siren/docs/config",draft:!1,unlisted:!1,editUrl:"https://github.com/Freymaurer/Siren/tree/main/docs/docs/config.mdx",tags:[],version:"current",sidebarPosition:2,frontMatter:{sidebar_label:"Config",sidebar_position:2},sidebar:"docsSidebar",previous:{title:"Installation",permalink:"/Siren/docs/installation"},next:{title:"Theme Variables",permalink:"/Siren/docs/themeVariables"}},u={},h=[];function d(e){const n={a:"a",code:"code",h1:"h1",p:"p",pre:"pre",...(0,a.R)(),...e.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(n.h1,{id:"config",children:"Config"}),"\n",(0,t.jsx)(n.p,{children:"Config variables are a concept used to adjust both rendering and behavior of some graphs."}),"\n",(0,t.jsxs)(n.p,{children:["A good example for this are GitGraphs ",(0,t.jsxs)(n.a,{href:"https://mermaid.js.org/syntax/gitgraph.html#customize-using-theme-variables",children:["offical documentation ","\ud83d\udcda"]}),"."]}),"\n",(0,t.jsx)(n.p,{children:"There are multiple ways to use config variables in Mermaid. Siren stays true to YAML and uses frontmatter syntax:"}),"\n",(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-yaml",children:"---\r\nconfig:\r\n    theme: base\r\n    gitGraph:\r\n        showBranches: false\r\n---\r\ngitGraph\r\n    commit\n"})}),"\n",(0,t.jsxs)(n.p,{children:["In this example ",(0,t.jsx)(n.code,{children:"showBranches"})," is part of the config options supported by GitGraphs."]}),"\n",(0,t.jsx)(n.h1,{id:"usage",children:"Usage"}),"\n",(0,t.jsx)(n.p,{children:"In Siren you can use config options in the following way:"}),"\n",(0,t.jsxs)(i.A,{groupId:"preferred-lang",queryString:!0,children:[(0,t.jsx)(s.A,{value:"fsharp",label:"F#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-fsharp",children:'let hotfix = "hotfix"\r\nsiren.git([\r\n    git.commit()\r\n    git.branch(hotfix)\r\n    git.checkout(hotfix)\r\n    git.commit()\r\n])\r\n    // use . syntax or pipe (|>) into siren.withTheme\r\n    .withTheme(theme.``base``)\r\n    .addGraphConfigVariable(gitGraphConfig.showBranches false)\r\n    .write()\n'})})}),(0,t.jsx)(s.A,{value:"csharp",label:"C#",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'string hotfix = "hotfix";\r\nstring actual =\r\n    siren.git([\r\n        git.commit(),\r\n        git.branch(hotfix),\r\n        git.checkout(hotfix),\r\n        git.commit(),\r\n    ])\r\n        .withTheme(theme.@base)\r\n        .addGraphConfigVariable(gitGraphConfig.showBranches(false))\r\n        .write();\n'})})}),(0,t.jsx)(s.A,{value:"py",label:"Python",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-python",children:'hotfix = "hotfix"\r\nactual = (\r\n    siren.git([\r\n        git.commit(),\r\n        git.branch(hotfix),\r\n        git.checkout(hotfix),\r\n        git.commit(),\r\n    ])\r\n        .with_theme(theme.base())\r\n        .add_graph_config_variable(git_graph_config.show_branches(False))\r\n        .write()\r\n)\n'})})}),(0,t.jsx)(s.A,{value:"js",label:"JavaScript",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-js",children:'const hotfix = "hotfix";\r\nconst actual =\r\n    siren.git([\r\n      git.commit(),\r\n      git.branch(hotfix),\r\n      git.checkout(hotfix),\r\n      git.commit(),\r\n  ])\r\n      .withTheme(theme.base)\r\n      .addGraphConfigVariable(gitGraphConfig.showBranches(false))\r\n      .write();\n'})})})]}),"\n",(0,t.jsx)(n.p,{children:"In case you cannot find a specifc config option you are looking for, you can always use:"}),"\n",(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:"graphConfig.custom(configName, configValue)\n"})}),"\n",(0,t.jsxs)(n.p,{children:["Here an example in C# using ",(0,t.jsx)(n.code,{children:"graphConfig.custom"}),"."]}),"\n",(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",children:'string hotfix = "hotfix";\r\nstring actual =\r\n    siren.git([\r\n        git.commit(),\r\n        git.branch(hotfix),\r\n        git.checkout(hotfix),\r\n        git.commit(),\r\n    ])\r\n        .withTheme(theme.@base)\r\n        .addGraphConfigVariable(graphConfig.custom("showBranches", "false"))\r\n        .write();\n'})})]})}function f(e={}){const{wrapper:n}={...(0,a.R)(),...e.components};return n?(0,t.jsx)(n,{...e,children:(0,t.jsx)(d,{...e})}):d(e)}},9365:(e,n,r)=>{r.d(n,{A:()=>s});r(6540);var t=r(4164);const a={tabItem:"tabItem_Ymn6"};var i=r(4848);function s(e){let{children:n,hidden:r,className:s}=e;return(0,i.jsx)("div",{role:"tabpanel",className:(0,t.A)(a.tabItem,s),hidden:r,children:n})}},1470:(e,n,r)=>{r.d(n,{A:()=>y});var t=r(6540),a=r(4164),i=r(3104),s=r(6347),o=r(205),l=r(7485),c=r(1682),u=r(9466);function h(e){return t.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,t.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}function d(e){const{values:n,children:r}=e;return(0,t.useMemo)((()=>{const e=n??function(e){return h(e).map((e=>{let{props:{value:n,label:r,attributes:t,default:a}}=e;return{value:n,label:r,attributes:t,default:a}}))}(r);return function(e){const n=(0,c.X)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,r])}function f(e){let{value:n,tabValues:r}=e;return r.some((e=>e.value===n))}function g(e){let{queryString:n=!1,groupId:r}=e;const a=(0,s.W6)(),i=function(e){let{queryString:n=!1,groupId:r}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!r)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return r??null}({queryString:n,groupId:r});return[(0,l.aZ)(i),(0,t.useCallback)((e=>{if(!i)return;const n=new URLSearchParams(a.location.search);n.set(i,e),a.replace({...a.location,search:n.toString()})}),[i,a])]}function p(e){const{defaultValue:n,queryString:r=!1,groupId:a}=e,i=d(e),[s,l]=(0,t.useState)((()=>function(e){let{defaultValue:n,tabValues:r}=e;if(0===r.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!f({value:n,tabValues:r}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${r.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const t=r.find((e=>e.default))??r[0];if(!t)throw new Error("Unexpected error: 0 tabValues");return t.value}({defaultValue:n,tabValues:i}))),[c,h]=g({queryString:r,groupId:a}),[p,m]=function(e){let{groupId:n}=e;const r=function(e){return e?`docusaurus.tab.${e}`:null}(n),[a,i]=(0,u.Dv)(r);return[a,(0,t.useCallback)((e=>{r&&i.set(e)}),[r,i])]}({groupId:a}),b=(()=>{const e=c??p;return f({value:e,tabValues:i})?e:null})();(0,o.A)((()=>{b&&l(b)}),[b]);return{selectedValue:s,selectValue:(0,t.useCallback)((e=>{if(!f({value:e,tabValues:i}))throw new Error(`Can't select invalid tab value=${e}`);l(e),h(e),m(e)}),[h,m,i]),tabValues:i}}var m=r(2303);const b={tabList:"tabList__CuJ",tabItem:"tabItem_LNqP"};var x=r(4848);function v(e){let{className:n,block:r,selectedValue:t,selectValue:s,tabValues:o}=e;const l=[],{blockElementScrollPositionUntilNextRender:c}=(0,i.a_)(),u=e=>{const n=e.currentTarget,r=l.indexOf(n),a=o[r].value;a!==t&&(c(n),s(a))},h=e=>{let n=null;switch(e.key){case"Enter":u(e);break;case"ArrowRight":{const r=l.indexOf(e.currentTarget)+1;n=l[r]??l[0];break}case"ArrowLeft":{const r=l.indexOf(e.currentTarget)-1;n=l[r]??l[l.length-1];break}}n?.focus()};return(0,x.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,a.A)("tabs",{"tabs--block":r},n),children:o.map((e=>{let{value:n,label:r,attributes:i}=e;return(0,x.jsx)("li",{role:"tab",tabIndex:t===n?0:-1,"aria-selected":t===n,ref:e=>l.push(e),onKeyDown:h,onClick:u,...i,className:(0,a.A)("tabs__item",b.tabItem,i?.className,{"tabs__item--active":t===n}),children:r??n},n)}))})}function j(e){let{lazy:n,children:r,selectedValue:a}=e;const i=(Array.isArray(r)?r:[r]).filter(Boolean);if(n){const e=i.find((e=>e.props.value===a));return e?(0,t.cloneElement)(e,{className:"margin-top--md"}):null}return(0,x.jsx)("div",{className:"margin-top--md",children:i.map(((e,n)=>(0,t.cloneElement)(e,{key:n,hidden:e.props.value!==a})))})}function w(e){const n=p(e);return(0,x.jsxs)("div",{className:(0,a.A)("tabs-container",b.tabList),children:[(0,x.jsx)(v,{...e,...n}),(0,x.jsx)(j,{...e,...n})]})}function y(e){const n=(0,m.A)();return(0,x.jsx)(w,{...e,children:h(e.children)},String(n))}},8453:(e,n,r)=>{r.d(n,{R:()=>s,x:()=>o});var t=r(6540);const a={},i=t.createContext(a);function s(e){const n=t.useContext(i);return t.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(a):e.components||a:s(e.components),t.createElement(i.Provider,{value:n},e.children)}}}]);