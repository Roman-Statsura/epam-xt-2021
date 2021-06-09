function func(str){
const posOp = [];
const operators = ['+', '-', '*', '/', '='];
let arr =  str.replace('=','').split(/[\+\-\*\/\=]/).map(Number);
str.split('').forEach(element => {
    if(operators.indexOf(element)!=-1){
        posOp.push(element);
    }
});

let res = arr[0];

posOp.forEach((el,i)=>{
    if(el ==="+"){
        res+=arr[i+1];
    }
    else if(el === "-"){
        res-=arr[i+1];
    }
    else if(el ==="*"){
        res*=arr[i+1];
    }
    else if(el === "/"){
        res/=arr[i+1];
    }
})
return res.toFixed(2);
}
console.log(func("3.5 +4*10-5.3 /5 ="));