
function setRefs(json) {
    let refs = [];
    let ids = [];
    var str = "";
    function getAllRefsAndIds(obj, outerAttr, outerObj) {
        //str += "" + 0 + " " + typeof(obj) + " " + obj + "\n";
        for (let attribute in obj) {
            
            if (attribute === "$ref") {
                refs.push({ attr: outerAttr, id: obj[attribute], obj: outerObj });
            } else if (attribute === "$id") {
                ids.push({ attr: outerAttr, id: obj[attribute], obj: outerObj });
            }else if (obj[attribute] !== null && attribute[0] !== '_' && typeof (obj[attribute]) === "object") {
                getAllRefsAndIds(obj[attribute], attribute, obj);
            }
        } 
    }
    var outerJson = { json: json };
    getAllRefsAndIds(json, "json", outerJson );
    for (let ref of refs) {
        for (let id of ids) {
            if (ref.id === id.id) {
                ref.obj[ref.attr] = id.obj[id.attr];
            }
        }
    }
    return refs.join("\n");
}