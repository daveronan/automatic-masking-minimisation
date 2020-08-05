addpath(genpath('/import/c4dm-scratch/davidr/BayesianMixing'))
load('RedToBlueStems.mat');

Qs = [1 0.6 0.3 0.2 0.2 1];
FREQs = [75 100 250 750 2500 7500];

eqGainUB = zeros(size(AudioData, 2) * 6 , 1);
eqGainUB(1:(size(AudioData, 2) * 6 )) = 3;

eqGainLB = zeros(size(AudioData, 2) * 6, 1);
eqGainLB(1:(size(AudioData, 2) * 6)) = -3;

thresholdUB = zeros(size(AudioData, 2) * 6, 1);
thresholdUB(1:(size(AudioData, 2) * 6)) = 0;

thresholdLB = zeros(size(AudioData, 2) * 6, 1);
thresholdLB(1:(size(AudioData, 2) * 6)) = -50;

tauAttackUB = zeros(size(AudioData, 2) * 6, 1);
tauAttackUB(1:(size(AudioData, 2) * 6)) = 0.25;

tauAttackLB = zeros(size(AudioData, 2) * 6, 1);
tauAttackLB(1:(size(AudioData, 2) * 6)) = 0.005;

tauReleaseUB = zeros(size(AudioData, 2) * 6, 1);
tauReleaseUB(1:(size(AudioData, 2) * 6)) = 3.0;

tauReleaseLB = zeros(size(AudioData, 2) * 6, 1);
tauReleaseLB(1:(size(AudioData, 2) * 6)) = 0.005;

xUB = [eqGainUB; thresholdUB; tauAttackUB; tauReleaseUB];
xLB = [eqGainLB; thresholdLB; tauAttackLB; tauReleaseLB];

options = optimoptions('particleswarm', 'Display', 'iter', 'UseParallel', true, 'FunctionTolerance', 0.5, 'ObjectiveLimit', 0);

fun = @(x)MaskingMinimisationFunctionNegativeSMREQ(x, AudioData, Qs, FREQs);
nvars = size(xUB, 1);

[x,fval,exitflag] = particleswarm(fun, nvars, xLB, xUB, options)
save('RedToBlueStemsMixParameters.mat', 'x', 'fval', 'exitflag');

[BadMix, GoodMix]  = MixAudioEQDRCParticleSwarmEQ(AudioData, x, Qs, FREQs);

audiowrite('RedToBlueStemsMixedEQ.wav', GoodMix, 44100);
audiowrite('RedToBlueStemsNotMixedEQ.wav', BadMix, 44100);
