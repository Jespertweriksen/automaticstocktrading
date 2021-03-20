using System;
using Keras.Layers;
using Keras.Models;
using Numpy;

namespace MachineLearning
{
    public class kerasnet
    {
       
            public static void TestXOR()
            {
            NDarray x = np.array(new float[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } });
            NDarray y = np.array(new float[] {0, 1, 1, 0 });

            var model = new Sequential();
            model.Add(new Dense(32, activation: "relu", input_shape: new Keras.Shape(2)));
            model.Add(new Dense(64, activation: "relu"));
            model.Add(new Dense(1, activation: "sigmoid"));

            model.Compile(optimizer: "sgd", loss: "binary_crossentropy", metrics: new string[] { "accuracy" });
            model.Fit(x, y, batch_size: 2, epochs: 1000, verbose: 1);

            string json = model.ToJson();
            System.IO.File.WriteAllText("model.json", json);
            model.SaveWeight("model.h5");

            var loaded_model = Sequential.ModelFromJson(System.IO.File.ReadAllText("model.json"));
            loaded_model.LoadWeight("model.h5");

        }
       
    }
}
