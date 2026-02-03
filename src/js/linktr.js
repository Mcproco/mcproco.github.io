const linktr = document.getElementById("linktr");
const directories = {
    "HOME" : "/",
    "COMMUNITY" : "/src/html/community/",
    "FORMS" : "/src/html/forms/",
    "PAPER" : "/src/html/paper/",
    "PROJECT" : "/src/html/project/",
    "SOURCES" : "/src/html/sources/",
    "LOGS" : "/src/html/logs/",
    "REFLECTION" : "/src/html/reflection/"
}

async function populate(name, dir) {

    const resp = await fetch(dir + "index.html");
    const obj = document.createElement("a");
    obj.text = `[ ${name} ]`;

    obj.href = dir

    return obj;

}

async function init() {

    let objs = [];

    for (key in directories) {

        let obj = await populate(key, directories[key]);
        objs.push(obj);

    }

    for (i in objs) {
        linktr.appendChild(objs[i]);
    }
}

init();