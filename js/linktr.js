const linktr = document.getElementById("linktr");
const directories = {
    "COMMUNITY" : "community/",
    "FORMS" : "forms/",
    "PAPER" : "paper/",
    "PROJECT" : "project/",
    "SOURCES" : "sources/",
    "LOGS" : "logs/",
    "REFLECTION" : "reflection/"
}

function populate(name, dir) {

    const obj = document.createElement("a");
    obj.text = `${name}`;
    obj.href = dir

    return obj;

}

function init() {

    let objs = [];

    for (key in directories) {

        let obj = populate(key, directories[key]);
        objs.push(obj);

    }

    for (i in objs) {
        linktr.appendChild(objs[i]);
    }
}

init();