    #pragma strict
     
    var pivot : Vector3;
    var speed : float = 45.0;
     
    function Start() {
    var bounds : Bounds;
    bounds.center = transform.position;
     
    var transforms = transform.root.GetComponentsInChildren(Transform);
    
    for (var trans : Transform in transforms) {
    bounds.Encapsulate(trans.position);
    }
    pivot = bounds.center;
    }
     
    function Update() {
    if (Input.GetKey(KeyCode.LeftArrow)) {
    transform.root.RotateAround(pivot, Vector3.up, Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.RightArrow)) {
    transform.root.RotateAround(pivot, Vector3.down, Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.UpArrow)) {
    transform.root.RotateAround(pivot, Vector3.right, Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.DownArrow)) {
    transform.root.RotateAround(pivot, Vector3.left, Time.deltaTime * speed);
    }
  
    

    
    
    }