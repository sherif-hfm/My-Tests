let squarer;

function loadWebAssembly(fileName) {
    return fetch(fileName)
      .then(response => response.arrayBuffer())
      .then(bits => WebAssembly.compile(bits))
      .then(module => { return new WebAssembly.Instance(module) });
};

loadWebAssembly('test.wasm')
  .then(instance => {
      squarer = instance.exports._Z7squareri;
      console.log('Finished compiling! Ready when you are...');
      console.log(squarer(4));
  });