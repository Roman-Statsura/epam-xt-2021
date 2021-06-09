function func(str){
    const separator = ["?", "!", ":", ";", ",", ".", " ", "\t"];
    const arr = str.split('');
    const rep = new Set();
    let start = 0;
    const words = [];

    arr.forEach((el,i) => {
        if(separator.indexOf(el) != -1){
            words.push(str.substr(start, i - start));
            start = i + 1;
        }
    });
    words.push(str.substr(start));

    words.forEach(word=> {
        word.split('').forEach((el, i)=> {
            if (!rep.has(el) && word.indexOf(el, i + 1) != -1) {
                rep.add(el);
            }
        });
    });

    return arr.filter((el)=>!rep.has(el)).join('');
}
console.log(func("У попа была собака"));