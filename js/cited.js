const div = document.getElementById("CitedLinks")
const interviews = {

    "Ekberg" : "https://docs.google.com/document/d/1jrwpq_HP4gG-c8_wtgDlcHWMqrw8gRqf_zT6NxdShyY/edit?tab=t.0",
    "Giddings" : "https://docs.google.com/document/d/1idLtXd7p0X25Wnw5NIVVRYNYs1aTAde5dKFEKw0RKZA/edit?tab=t.0",

}

function populate() {

    for (let i = 0; i < div.childElementCount; i++) {

        const node = div.children[i];
        const link = getLink(node);
        if (link == null) {
            continue;
        }

        const obj = document.createElement("a");
        const wrapper = document.createElement("sup");
        wrapper.textContent = `[${i + 1}] `;
        obj.href = link;
        obj.target = "_blank"
        console.log(link)

        
        node.prepend(obj);
        obj.appendChild(wrapper);

    }

}

function getLink(node) {

    for (key in interviews) {

        if (node.textContent.startsWith(key)) {
            return interviews[key];
        }

    }

    const textContent = String(node.textContent)
    const i = textContent.indexOf("https://")
    if (i == null) {
        return null;
    }

    const v = textContent.indexOf(' ', i)
    if (v == null) {
        return null;
    }

    return textContent.substring(i, v - 1);

}


if (div != null) {
    populate();
}
