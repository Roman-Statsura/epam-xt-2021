class Service{
    #repository = [];

    add(obj){
        if (this.getById(obj.id)) return null;
        if (typeof obj !== "object") return null;
        if (typeof obj.id !== "string") return null;
        this.#repository.push(obj);
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
            this.#repository[index] = obj;
        }
    }
}

const personOne = {
    id : "1",
    name : "Roman",
    age : "22"
}
const personTwo = {
    id : "2",
    name : "Oleg",
    age : "30"
}
const personThree = {
    id : "3",
    name : "Ivan",
    age : "90"
}
const personFour = {
    id : "4",
    name : "Olga",
    age : "20"
}
const personFive = {
    id : "5",
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
