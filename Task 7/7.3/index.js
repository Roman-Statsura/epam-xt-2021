class Service{
    #repository = [];
    curId = "1";

    add(obj){
        if (typeof obj !== "object") return null;
        Object.assign(obj,{id:this.curId})
        this.#repository.push(obj);
        this.curId = String((+this.curId)+1);
    }
    getById = (id)=> this.#repository.find(el=>el.id===id) || null;

    getAll = () => this.#repository;

    deleteById = (id)=> {
        const obj = this.getById(id);
        if(obj){
            const index = this.#repository.findIndex(obj=>obj.id===id); 
            this.#repository.splice(index,1);
        }
        return obj;
    }
    updateById(id,obj){
        const oldObj = this.getById(id);
        if(oldObj){
            for(let key of Object.keys(oldObj)){
                if(key !== "id"){
                    oldObj[key] = obj[key];
                }
            }
        }else return null;
    }
    replaceById(id,obj){
        const index = this.#repository.findIndex(obj=>obj.id===id); 
        if(index!=-1){
            Object.assign(obj,{id:this.curId})
            this.#repository[index] = obj;
        }
    }
}

const personOne = {
    name : "Roman",
    age : "22"
}
const personTwo = {
    name : "Oleg",
    age : "30"
}
const personThree = {
    name : "Ivan",
    age : "90"
}
const personFour = {
    name : "Olga",
    age : "20"
}
const personFive = {
    name : "Marat",
    age : "80"
}

const storage = new Service();
storage.add(personOne);
storage.add(personTwo);
storage.add(personFour);
console.log(storage.getById("1"));
console.log(storage.deleteById("2"));
storage.updateById("1",personThree);
storage.replaceById("1",personFive);
