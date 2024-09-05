DROP TABLE IF EXISTS patient_treatments;
DROP TABLE IF EXISTS treatments;
DROP TABLE IF EXISTS diagnoses;
DROP TABLE IF EXISTS diseases;
DROP TABLE IF EXISTS doctors;
DROP TABLE IF EXISTS patients;

CREATE TABLE patients (
                          id SERIAL PRIMARY KEY,
                          name TEXT NOT NULL,
                          birthdate DATE NOT NULL,
                          gender BOOLEAN NOT NULL,
                          address TEXT
);

CREATE TABLE doctors (
                         id SERIAL PRIMARY KEY,
                         name TEXT NOT NULL,
                         specialty TEXT NOT NULL,
                         years_experience INTEGER
);

CREATE TABLE diseases (
                          id SERIAL PRIMARY KEY,
                          name TEXT NOT NULL,
                          severity TEXT NOT NULL
);

CREATE TABLE diagnoses (
                           id SERIAL PRIMARY KEY,
                           patient_id INTEGER NOT NULL,
                           disease_id INTEGER NOT NULL,
                           diagnosis_date TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
                           doctor_id INTEGER NOT NULL,
                           FOREIGN KEY (patient_id) REFERENCES patients(id) ON DELETE CASCADE,
                           FOREIGN KEY (disease_id) REFERENCES diseases(id) ON DELETE CASCADE,
                           FOREIGN KEY (doctor_id) REFERENCES doctors(id) ON DELETE CASCADE
);

CREATE TABLE treatments (
                            id SERIAL PRIMARY KEY,
                            name TEXT NOT NULL,
                            cost FLOAT NOT NULL
);

CREATE TABLE patient_treatments (
                                    id SERIAL PRIMARY KEY,
                                    patient_id INTEGER NOT NULL,
                                    treatment_id INTEGER NOT NULL,
                                    start_date TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
                                    end_date TIMESTAMP WITH TIME ZONE,
                                    FOREIGN KEY (patient_id) REFERENCES patients(id) ON DELETE CASCADE,
                                    FOREIGN KEY (treatment_id) REFERENCES treatments(id) ON DELETE CASCADE
);

-- Insert sample data
INSERT INTO patients (name, birthdate, gender, address) VALUES
                                                            ('Peter', '1985-06-15', TRUE, '123 Main St'),
                                                            ('Bob', '1990-07-20', TRUE, '456 Pine St');

INSERT INTO doctors (name, specialty, years_experience) VALUES
                                                            ('Dr. Smith', 'Cardiology', 15),
                                                            ('Dr. Johnson', 'Neurology', 10);

INSERT INTO diseases (name, severity) VALUES
                                          ('Flu', 'Low'),
                                          ('Diabetes', 'High');

INSERT INTO diagnoses (patient_id, disease_id, doctor_id) VALUES
                                                              (1, 1, 1),
                                                              (2, 2, 2);

INSERT INTO treatments (name, cost) VALUES
                                        ('Antibiotics', 50.00),
                                        ('Insulin therapy', 100.00);

INSERT INTO patient_treatments (patient_id, treatment_id, end_date) VALUES
                                                                        (1, 1, '2024-09-10'),
                                                                        (2, 2, NULL);