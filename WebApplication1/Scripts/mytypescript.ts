class jobcategory{
    public name: string = "";
    validate() {
        alert('called validate');
    }
}

class jobcategoryModified extends jobcategory {
    validate() {
        alert('jobcategoryModified called');
    }
}